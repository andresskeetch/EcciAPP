using System;
using System.Collections.ObjectModel;
using Core.NotifyApp.Models;
using Core.NotifyApp.Service;

namespace Core.NotifyApp.ViewModels
{
    class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties 
        public ObservableCollection<Menu> MyMenu { get; set; }
        #endregion
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public ScheduleTodayViewModel ScheduleToday { get; set; }

        #endregion

        

        #region Contructors
        public MainViewModel()
        {

            instance = this;

            navigationService = new NavigationService();

            this.Login = new LoginViewModel();

            this.loadMenu();
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
                Icon = "ic_schedule",
                PageName = "LoginPage",
                Title = "Cerrar Sesion"
            });
        }
        #endregion
    }
}
