using Core.NotifyApp.Service;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.NotifyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulePage : ContentPage
    {
        #region Services
        NavigationService navigationService;
        #endregion
        public SchedulePage ()
		{
			InitializeComponent ();
            schedule.CellDoubleTapped += Schedule_CellDoubleTapped;
            navigationService = new NavigationService();
        }

        private void Schedule_CellDoubleTapped(object sender, CellTappedEventArgs e)
        {
            if (e.Appointment == null)
                return;

            navigationService.NavigateOnMaster("ScheduleDetailPage", e.Appointment);
        }
    }
}