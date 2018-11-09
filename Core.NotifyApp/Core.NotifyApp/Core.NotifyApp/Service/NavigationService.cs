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
                    MainViewModel.getInstance().Login = new LoginViewModel();
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

        public async Task NavigateOnMaster(string pageName, object param = null)
        {

            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "SchedulePage":
                    MainViewModel.getInstance().Schedule = new ScheduleViewModel();
                    await App.Navigator.PushAsync(new SchedulePage());
                    break;
                case "NotificationPage":
                    MainViewModel.getInstance().Notification = new NotificationViewModel();
                    await App.Navigator.PushAsync(new NotificationPage());
                    break;
                case "ScheduleDetailPage":
                    MainViewModel.getInstance().ScheduleDetail = new ScheduleDetailViewModel(param);
                    await App.Navigator.PushAsync(new ScheduleDetailPage());
                    break;
                case "MapPage":
                    MainViewModel.getInstance().Map = new MapViewModel();
                    await App.Navigator.PushAsync(new MapPage());
                    break;
                default:
                    break;
            }
        }

        public async Task BackOnMaster() {

            await App.Navigator.PopAsync();
        } 

    }
}
