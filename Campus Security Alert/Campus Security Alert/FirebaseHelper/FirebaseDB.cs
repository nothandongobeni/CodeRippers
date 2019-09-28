using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;

namespace Campus_Security_Alert.FirebaseHelper
{
    class FirebaseDB
    {
        public static FirebaseDatabase GetFirebaseDatabase()
        {
            FirebaseDatabase DB;
            var app = FirebaseApp.InitializeApp(Application.Context);
            if(app == null)
            {
                var option =  new FirebaseOptions.Builder()
                    .SetApiKey("AIzaSyDEOFWYc7-f6gGwxdO2UHH5tbDf-wv-JUc")
                    .SetApplicationId("campus-security-alert")
                    .SetDatabaseUrl("https://campus-security-alert.firebaseio.com")
                    .SetProjectId("campus-security-alert")
                    .SetStorageBucket("campus-security-alert.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, option);
                DB = FirebaseDatabase.GetInstance(app);
                return DB;
            }
            else
            {
                DB = FirebaseDatabase.GetInstance(app);
                return DB;
            }
        }
    }
}