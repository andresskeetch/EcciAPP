using Core.Models.Models;
using Core.NotifyApp.Service;
using Core.NotifyApp.Tools;
using Core.Service.Communication;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Core.NotifyApp.ViewModels
{
    public class ScheduleDetailViewModel : BaseViewModel
    {
        #region Properties
        private ScheduleAll schedule;
        private bool _isRunning;
        private bool _isEnable;
        NavigationService navigationService;
        private string description;
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
        public ScheduleAll Schedule
        {
            get { return this.schedule; }
            set { SetValue(ref this.schedule, value); }
        }
        public string Description
        {
            get { return this.description; }
            set { SetValue(ref this.description, value); }
        }
        #endregion
        #region Constructors
        public ScheduleDetailViewModel(object schedule)
        {
            this.Schedule = (Core.Models.Models.ScheduleAll)schedule;
            navigationService = new NavigationService();
            this.loadPage();
        }
        #endregion
        #region Command
        public ICommand updateCommand
        {
            get
            {
                return new RelayCommand(update);
            }
        }
        #endregion
        #region Methods
        public void loadPage() {

        }

        async void update() {
            if (string.IsNullOrEmpty(Description))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La descripcion es obligatoria.",
                    "Aceptar");
                return;
            }
            this.onLoading();
            if (!await Connection.CheckConnection())
            {
                this.offLoading();
                return;
            }
            Schedule.Description = Description;
            var result = Core.Service.Communication.Schedule.Update(Schedule, App.User.User.UserID);
            await Application.Current.MainPage.DisplayAlert(
                    "Exito",
                    "Se enviaron los Datos.",
                    "Aceptar");
            await navigationService.BackOnMaster();
        }
        void offLoading() {
            IsRunning = false;
            IsEnable = true;
        }
        void onLoading()
        {
            IsRunning = true;
            IsEnable = false;
        }
        #endregion
    }
}
