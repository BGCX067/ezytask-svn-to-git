using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace ezytask.infrastructure
{
    public interface ICanDisplaySavePopup
    {
        Panel PopupHolder
        {
            get;
        }
    }
}
