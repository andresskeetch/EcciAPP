using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.NotifyApp.Behaviors
{
    internal class ScheduleViewBehavior : Behavior<ContentView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);
            schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("schedule");
        }

        protected override void OnDetachingFrom(ContentView bindable)
        {
            base.OnDetachingFrom(bindable);
            schedule = null;
        }
    }
}
