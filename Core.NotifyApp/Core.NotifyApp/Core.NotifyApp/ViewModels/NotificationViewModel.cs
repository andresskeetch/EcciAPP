using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Core.NotifyApp.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Core.Models.Models.Notification> notifications;
        private bool isRefreshing;
        private List<Core.Models.Models.Notification> notificationsList;
        #endregion

        #region Properties
        public ObservableCollection<Core.Models.Models.Notification> Notifications
        {
            get { return this.notifications; }
            set { SetValue(ref this.notifications, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public NotificationViewModel() {
            this.loadNotifications();
        }
        #endregion

        #region Methods
        private void loadNotifications () {
            setRefreshingListview(true);
            this.notificationsList = Core.Service.Communication.Notification.GetNotification(App.User.User.Person.PersonID).ToList();
            this.Notifications = new ObservableCollection<Core.Models.Models.Notification>(this.notificationsList.OrderByDescending(f => f.Date));
            setRefreshingListview(false);
        }
        void setRefreshingListview(bool value) {
            this.IsRefreshing = value;
        }
        public void addNotification(Core.Models.Models.Notification noty) {
            setRefreshingListview(true);
            this.notificationsList.Add(noty);
            this.Notifications = new ObservableCollection<Core.Models.Models.Notification>(this.notificationsList.OrderByDescending(f => f.Date));
            setRefreshingListview(false);
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(loadNotifications); }
        }
        #endregion
    }
}
