using Core.NotifyApp.Service;
using Core.NotifyApp.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Core.NotifyApp.Models
{
    public class Menu
    {
        #region Services
        NavigationService navigationService;
        #endregion
        #region Properties

        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        #endregion

        #region Commands

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }



        #endregion

        #region Constructors

        public Menu() {
            navigationService = new NavigationService();
        }
        #endregion

        #region Methods
        private void Navigate()
        {
            switch (PageName)
            {
                case "LoginPage":
                    MainViewModel.getInstance().Login = new LoginViewModel();
                    navigationService.SetMainPage("LoginPage");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
