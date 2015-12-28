using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ezytask.infrastructure
{
    public class PresenterBase<IViewInterface>
    {
        protected IViewInterface m_View;
        protected PresenterBase(IViewInterface view)
        {
            Trace.WriteLine(
                String.Format("Presenter created: {0}", this.GetType().FullName)); 

            m_View = view;
        }

        protected void DisplaySavePopup()
        {
            if (m_View is ICanDisplaySavePopup)
            {
                utilities.Utilities.ShowPopup((m_View as ICanDisplaySavePopup).PopupHolder);
            }
            else
            {
                Trace.WriteLine("Attempted to display the save popup on a view that does not implement ICanDisplaySavePopup.");
            }
        }
    }
}
