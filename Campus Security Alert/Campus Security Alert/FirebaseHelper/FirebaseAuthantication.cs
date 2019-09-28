using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.Net;
using Android.Widget;
using Firebase.Auth;
using Firebase;

namespace Campus_Security_Alert.FirebaseHelper
{
    class FirebaseAuthantication
    {
        public FirebaseAuth GetFirebaseAuth()
        {
            FirebaseAuth auth;
            var app = FirebaseApp.InitializeApp(Application.Context);
            if(app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetApiKey("AIzaSyDEOFWYc7-f6gGwxdO2UHH5tbDf-wv-JUc")
                    .SetApplicationId("campus-security-alert")
                    .SetDatabaseUrl("https://campus-security-alert.firebaseio.com")
                    .SetProjectId("campus-security-alert")
                    .SetStorageBucket("campus-security-alert.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, option);
                auth = FirebaseAuth.GetInstance(app);
                return auth;
            }
            auth = FirebaseAuth.GetInstance(app);
            return auth;
        }
    }
}