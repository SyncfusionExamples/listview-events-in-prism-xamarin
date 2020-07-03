using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields

        SfListView ListView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.SwipeEnded += ListView_SwipeEnded;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView.SwipeEnded -= ListView_SwipeEnded;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Event
        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset > 100)
                ListView.ResetSwipe();
        }
        #endregion
    }
}