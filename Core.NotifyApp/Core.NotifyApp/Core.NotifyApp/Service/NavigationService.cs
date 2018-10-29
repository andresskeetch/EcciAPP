using Core.NotifyApp.ViewModels;
using Core.NotifyApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.NotifyApp.Service
{
    public class NavigationService
    {
        public void SetMainPage(string pageName) {

            switch (pageName)
            {
                case "LoginPage":
                    Application.Current.MainPage = new LoginPage();
                    break;
                case "MasterPage":
                    MainViewModel.getInstance().ScheduleToday = new ScheduleTodayViewModel();
                    Application.Current.MainPage = new MasterPage();
                    break;
                default:
                    break;
            }

        }

        public async Task NavigateOnMaster(string pageName) {

            App.Master.IsPresented = false;
            switch (pageName)
            {
                default:
                    break;
            }
        }

        public async Task BackOnMaster() {

            await App.Navigator.PopAsync();
        } 

    }
}
