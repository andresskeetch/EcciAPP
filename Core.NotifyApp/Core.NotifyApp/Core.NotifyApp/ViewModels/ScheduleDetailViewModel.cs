using Core.Models.Models;
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
        private string description;
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
            var result = Core.Service.Communication.Schedule.Update(Schedule, App.User.User.UserID);
        }
        void offLoading() {

        }
        void onLoading()
        {

        }
        #endregion
    }
}
