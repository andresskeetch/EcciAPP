﻿using Core.Models.Models;
using GalaSoft.MvvmLight.Command;
using Syncfusion.SfSchedule.XForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using communitacion = Core.Service.Communication;

namespace Core.NotifyApp.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {

        #region Attributes
        private ObservableCollection<ScheduleAll> schedule;
        private IEnumerable<ScheduleAll> listScheduleToday;
        #endregion
        
        #region Constructors
        public ScheduleViewModel()
        {
            //do something
            this.loadSchedule();
        }
        #endregion

        #region Properties
        public ObservableCollection<ScheduleAll> Schedule
        {
            get { return this.schedule; }
            set { SetValue(ref this.schedule, value); }
        }
        #endregion

        #region Methods

        void loadSchedule () {
            this.listScheduleToday = communitacion.Schedule.GetScheduleToday(App.User.User.Person.PersonID);
            this.Schedule = new ObservableCollection<ScheduleAll>(this.listScheduleToday.OrderBy(f => f.Date));
        }

        #endregion
        #region Events

        #endregion
    }
}
