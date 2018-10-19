using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace App4
{
    [Activity(Label = "App4")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            prepareActioBar();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
        }

        private void prepareActioBar()
        {
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.Title = "Login";
        }
    }
}

