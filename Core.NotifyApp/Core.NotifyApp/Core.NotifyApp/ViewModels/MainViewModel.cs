using System;
using System.Collections.ObjectModel;
using System.Data;
using Core.NotifyApp.Models;
using Core.NotifyApp.Service;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using GalaSoft.MvvmLight.Threading;
using Core.Service.Communication;
using Core.Models.Models;

namespace Core.NotifyApp.ViewModels
{
    class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties 
        private ObservableCollection<Notification> signalrMessages;

        public ObservableCollection<Notification> SignalrMessages
        {
            get
            {
                return signalrMessages;
            }

            set
            {
                signalrMessages = value;
            }
        }
        public ObservableCollection<Menu> MyMenu { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }
        public ScheduleTodayViewModel ScheduleToday { get; set; }
        public ScheduleViewModel Schedule { get; set; }
        public ScheduleDetailViewModel ScheduleDetail { get; set; }
        public MapViewModel Map { get; set; }

        #endregion

        #region Contructors
        public MainViewModel()
        {

            instance = this;

            navigationService = new NavigationService();

            this.Login = new LoginViewModel();

            this.loadMenu();
            
            ConnectToSignalR();
        }


        private async Task ConnectToSignalR()
        {

            App.HubConnection = new HubConnection(Constants.uriSignalR);
            
            //Creating the hub proxy. That allows us to send and receive
            App.HubProxy = App.HubConnection.CreateHubProxy("NotificationHub");

            try
            {

                if (App.HubConnection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    App.HubConnection.StateChanged += HubConnection_StateChanged;
                    await App.HubConnection.Start();
                }
            }

            catch (Microsoft.AspNet.SignalR.Client.Infrastructure.StartException ex)
            {

                throw;
            }

            App.HubProxy.On<Notification>("Notificate", async (noty) => {

                DispatcherHelper.CheckBeginInvokeOnUI(() => {
                    //do something
                });
            });






        }
        void HubConnection_StateChanged(StateChange obj)
        {

            //You can check here the state of the signalr connection.
        }
        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel getInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            else
            {
                return instance;
            }
        }
        #endregion

        #region Methos
        private void loadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();

            MyMenu.Add(new Menu()
            {
                Icon = "ic_map",
                PageName = "MapPage",
                Title = "Mapa"
            });

            MyMenu.Add(new Menu()
            {
                Icon = "ic_schedule",
                PageName = "SchedulePage",
                Title = "Horario"
            });

            MyMenu.Add(new Menu()
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Cerrar Sesion"
            });
        }
        #endregion
    }
}
