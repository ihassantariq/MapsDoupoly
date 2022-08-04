using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;

namespace MapSampleForDoupoly.Droid
{
    [Activity(Label = "Maps Doupoply", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //location variables
        private const int RequestLocationId = 0;

        private readonly string[] LocationPermissions =
        {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation
         };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Initializing maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }


        protected override void OnStart()
        {
            base.OnStart();

            //calling location permission function

            GetLocationPermission();

        }

        //Setting up for permission

        void GetLocationPermission()
        {

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    //Location permission granted

                    
                }
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted)) { }

                // Permissions granted - display a message.
                else { }
                // Permissions denied - display a message.
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}
