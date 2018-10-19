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
using Core.Service.Communication;

namespace App4
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            prepareActionBar();

            SetContentView(Resource.Layout.Login);

            Button btnLogin = FindViewById<Button>(Resource.Id.IniciarSesion);
            var txtUserName = FindViewById<EditText>(Resource.Id.Email);
            var txtPassword = FindViewById<EditText>(Resource.Id.Password);

            btnLogin.Click += delegate
            {
                try
                {
                    var dialog = new AlertDialog.Builder(this);
                    if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                    {
                        dialog.SetTitle("Alerta");
                        dialog.SetMessage("Los campos son obligatorios.");
                        dialog.Show();
                        return;
                    }
                    var result = User.Authenticate(txtUserName.Text, txtPassword.Text);
                    if (result.authorization == Core.Models.Enums.Authorization.IsAuthenticated)
                    {
                        dialog.SetTitle("Alerta");
                        dialog.SetMessage("Inicio Sesion Exitoso.");
                        dialog.Show();
                    }
                    else if (result.authorization == Core.Models.Enums.Authorization.IncorrectUserPassword)
                    {
                        dialog.SetTitle("Alerta");
                        dialog.SetMessage("Datos Incorrectos.");
                        dialog.Show();
                    }
                }
                catch (Exception e)
                {
                    var dialog = new AlertDialog.Builder(this);
                    dialog.SetTitle("Error");
                    dialog.SetMessage(e.Message);
                    dialog.Show();
                }
            };
        }

        private void prepareActionBar()
        {
            ActionBar.Hide();
        }
    }
}