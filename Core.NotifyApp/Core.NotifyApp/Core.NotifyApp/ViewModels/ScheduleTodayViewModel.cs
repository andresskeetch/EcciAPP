using communitacion = Core.Service.Communication;
using Core.Models.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Core.NotifyApp.ViewModels
{
    class ScheduleTodayViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ScheduleAll> scheduleToday;
        private bool isRefreshing;
        private IEnumerable<ScheduleAll> listScheduleToday;
        #endregion

        #region Properties
        public ObservableCollection<ScheduleAll> ScheduleToday
        {
            get { return this.scheduleToday; }
            set { SetValue(ref this.scheduleToday, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion

        #region Constructors
        public ScheduleTodayViewModel()
        {
            this.loadScheduleToday();
        }


        #endregion

        #region Methods
        private void loadScheduleToday()
        {
            setRefreshingListview(true);
            this.listScheduleToday = communitacion.Schedule.GetScheduleToday(communitacion.Constants.User.User.Person.PersonID);
            this.ScheduleToday = new ObservableCollection<ScheduleAll>(this.listScheduleToday.OrderBy(f=>f.Date));
            setRefreshingListview(false);
        }

        private void setRefreshingListview(bool value) {
            this.IsRefreshing = value;
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(loadScheduleToday); }
        }
        #endregion
    }
}
