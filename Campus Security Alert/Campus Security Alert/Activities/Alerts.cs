using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Location;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Campus_Security_Alert.FirebaseHelper;
using Campus_Security_Alert.MapHelper;
using Java.Util;

namespace Campus_Security_Alert.Activities
{
    [Activity(Label = "Alerts")]
    public class Alerts : Activity, IOnMapReadyCallback
    {
        private Button BtnPanic;



        GoogleMap gMap;
        readonly string[] permission = { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation };
        const int requestLocationId = 0;

        string id = "12345";
        LocationRequest locationRequest;
        FusedLocationProviderClient locationClient;
        Location lastLocation;
        static int UPDATE_INTERVAL = 5;
        static int UPDATE_FASTEST_INTERVAL = 5;
        static int DISPLACEMENT = 3;

        private LocationCallBackHelper locationCallBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.alert_layout);
            BtnPanic = FindViewById<Button>(Resource.Id.BtnPanic);
            BtnPanic.Click += BtnPanic_Click;


            var mapFrag = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.fragMap);
            mapFrag.GetMapAsync(this);
            CheckPermission();
            CreateLocationRequest();
            GetLocation();
            StartLocationUpdate();


        }

        private void BtnPanic_Click(object sender, EventArgs e)
        {
            
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            gMap = googleMap;
            gMap.MapType = GoogleMap.MapTypeHybrid;

            //gMap.CameraIdle += GMap_CameraIdle;
            //string mapKey = Resources.GetString(Resource.String.mapKey);
            //mapHelper = new MapHelper(mapKey);
        }
        private bool CheckPermission()
        {
            bool permisionGranted = false;
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted && ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {
                permisionGranted = false;
                RequestPermissions(permission, requestLocationId);
            }
            else
            {
                return true;
            }
            return permisionGranted;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] gra0ntResults)
        {
            if (gra0ntResults[0] == (int)Permission.Granted)
            {
                Toast.MakeText(this, "Permission was granted", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Permission was denied", ToastLength.Long).Show();
            }
        }
        private void CreateLocationRequest()
        {
            locationRequest = new LocationRequest();
            locationRequest.SetInterval(UPDATE_INTERVAL);
            locationRequest.SetFastestInterval(UPDATE_FASTEST_INTERVAL);
            locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequest.SetSmallestDisplacement(DISPLACEMENT);
            locationClient = LocationServices.GetFusedLocationProviderClient(this);
            locationCallBack = new LocationCallBackHelper();
            locationCallBack.CurrentLocation += LocationCallBack_CurrentLocation;
        }

        private void LocationCallBack_CurrentLocation(object sender, LocationCallBackHelper.OnLocationCapturedEventArgs e)
        {
            lastLocation = e.location;
            LatLng position = new LatLng(lastLocation.Latitude, lastLocation.Longitude);
            gMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(position, 15));


        }

        private async void GetLocation()
        {
            if (!CheckPermission())
            {
                return;
            }
            lastLocation = await locationClient.GetLastLocationAsync();
            if (lastLocation != null)
            {
                LatLng pos = new LatLng(lastLocation.Latitude, lastLocation.Longitude);
                gMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(pos, 13));
            }
        }
        private void StartLocationUpdate()
        {
            if (CheckPermission())
            {
                locationClient.RequestLocationUpdates(locationRequest, locationCallBack, null);
            }
        }
    }
}