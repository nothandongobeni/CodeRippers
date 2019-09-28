using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Location;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Campus_Security_Alert.FirebaseHelper;
using Campus_Security_Alert.MapHelper;
using Firebase.Database;
using Java.Util;

namespace Campus_Security_Alert.Activities
{
    [Activity(Label = "Dashboad")]
    public class Dashboad : Activity
    {
        private CardView CVAlerts;
        private CardView CVLogout;
        private CardView CVAbout;
        private CardView CVFQA;
        private CardView CVStudentsChat;
        private CardView CVProfile;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.dashboard);
            CVAlerts = FindViewById<CardView>(Resource.Id.CV_Alerts);
            CVLogout = FindViewById<CardView>(Resource.Id.CV_Logout);
            CVProfile = FindViewById<CardView>(Resource.Id.CV_Profile);
            CVFQA = FindViewById<CardView>(Resource.Id.CV_FQA);
            CVAbout = FindViewById<CardView>(Resource.Id.CV_About);
            CVStudentsChat = FindViewById<CardView>(Resource.Id.CV_StudentsChat);


            CVAlerts.Click += CVAlerts_Click;

        }
        private void CVAlerts_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Alerts));
            StartActivity(intent);
        }
    }
}