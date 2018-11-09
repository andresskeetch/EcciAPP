
using Core.Models.Models;
using Core.NotifyApp.Service;
using Core.NotifyApp.Views;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

namespace Core.NotifyApp
{
	public partial class App : Application
	{
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }

        public static HubConnection HubConnection { get; internal set; }

        public static IHubProxy HubProxy { get; internal set; }

        public static Login User { get; internal set; }
        NavigationService navigationService;
        public App ()
		{
			InitializeComponent();
            navigationService = new NavigationService();
            if (User == null)
            {
                MainPage = new LoginPage();
            }
            else {
                navigationService.SetMainPage("MasterPage");
            }
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        
    }
}
