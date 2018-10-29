using Core.Service.Communication;
using Core.NotifyApp.Tools;
using Core.NotifyApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Core.NotifyApp.Service;
using Android.Content;
using Android.Views;

namespace Core.NotifyApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Attributes

        private string _password;
        private string _userName;
        private bool _isRunning;
        private bool _isEnable;

        #endregion

        #region Properties
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                SetValue(ref _userName, value);
            }
        }
        public string Password
        {
            get {
                return this._password;
            }
            set {
                SetValue(ref _password, value);
            }
        }
        public bool IsRemembered { get; set; }
        public bool IsRunning
        {
            get
            {
                return this._isRunning;
            }
            set
            {
                SetValue(ref _isRunning, value);
            }
        }
        public bool IsEnable
        {
            get
            {
                return this._isEnable;
            }
            set
            {
                SetValue(ref _isEnable, value);
            }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;
            navigationService = new NavigationService();
        }
        #endregion

        #region Services
        NavigationService navigationService;
        #endregion

        #region Command
        public ICommand loginCommand
        {
            get
            {
                return new RelayCommand(login);
            }
        }



        #endregion



        #region Methods
        async void login()
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar el email.",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar la contraseña.",
                    "Aceptar");
                return;
            }
            this.onLoading();
            if (!await Connection.CheckConnection())
            {
                this.offLoading();
                return;
            }
            var result = await User.Authenticate(UserName, this.Password);
            if (result.authorization == Core.Models.Enums.Authorization.IsAuthenticated)
            {

                this.UserName = string.Empty;
                this.Password = string.Empty;

                Constants.User = result;

                if (this.IsRemembered)
                {
                    //do something
                }

                navigationService.SetMainPage("MasterPage");
            }
            else if (result.authorization == Core.Models.Enums.Authorization.IncorrectUserPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario o contraseña incorrectos.",
                    "Aceptar");
                this.offLoading();
            }
        }

        void onLoading()
        {
            this.IsEnable = false;
            this.IsRunning = true;
        }

        void offLoading()
        {
            this.IsEnable = true;
            this.IsRunning = false;
        }
        #endregion

    }
}
