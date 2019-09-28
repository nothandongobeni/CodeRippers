using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Campus_Security_Alert.FirebaseHelper;
using Firebase.Auth;
using Firebase.Database;
using Java.Lang;
using Java.Util;

namespace Campus_Security_Alert.Activities
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity, IOnSuccessListener, IOnFailureListener, IOnCompleteListener
    {
        FirebaseAuth auth;
        private Button BtnSignUp;
        private TextInputEditText InputEmail;
        private TextInputEditText InputPassword;
        private TextInputEditText InputFullname;
        private TextInputEditText InputCellPhone;
        private TextView AlreadyHaveAcc;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);
            BtnSignUp = FindViewById<Button>(Resource.Id.BtnSignUp);
            InputEmail = FindViewById<TextInputEditText>(Resource.Id.RegEmailAddress);
            InputPassword = FindViewById<TextInputEditText>(Resource.Id.RegPassword2);
            InputFullname = FindViewById<TextInputEditText>(Resource.Id.RegFullNames);
            InputCellPhone = FindViewById<TextInputEditText>(Resource.Id.RegCellPhone);
            AlreadyHaveAcc = FindViewById<TextView>(Resource.Id.txtAlreadyHaveAcc);





            AlreadyHaveAcc.Click += AlreadyHaveAcc_Click;

            BtnSignUp.Click += BtnSignUp_Click;
        }

        private void AlreadyHaveAcc_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            StartActivity(intent);
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Dashboad));
            StartActivity(intent);
            //Register();
        }

        private void Register()
        {
            auth = new FirebaseAuthantication().GetFirebaseAuth();
            auth.CreateUserWithEmailAndPassword(InputEmail.Text, InputPassword.Text)
                .AddOnSuccessListener(this)
                .AddOnFailureListener(this)
                .AddOnCompleteListener(this);

        }

        public void OnComplete(Task task)
        {
            
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Error");
            builder.SetMessage(e.Message);
            builder.SetNeutralButton("Ok", delegate
            {
                builder.Dispose();
            });
            builder.Dispose();
        }

        public void OnSuccess(Java.Lang.Object result)
        {

            HashMap data = new HashMap();
            data.Put("Emai", InputEmail.Text);
            data.Put("Password", InputPassword.Text);
            data.Put("Fullname", InputFullname.Text);
            data.Put("Phone", InputCellPhone.Text);
            

            DatabaseReference DBRef = FirebaseDB.GetFirebaseDatabase().GetReference("Users").Child(auth.CurrentUser.Uid);
            DBRef.SetValue(data);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Successful");
            builder.SetMessage("Your account has been successfully created");
            builder.SetNeutralButton("Ok", delegate
            {
                InputEmail.Text = string.Empty;
                InputPassword.Text = string.Empty;
                InputFullname.Text = string.Empty;
                InputCellPhone.Text = string.Empty;

                builder.Dispose();
            });
            builder.Dispose();
        }
    }
}