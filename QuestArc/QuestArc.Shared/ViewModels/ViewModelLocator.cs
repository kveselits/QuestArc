using System;
using System.Collections.Generic;
using System.Text;

namespace QuestArc.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator() { }

        private static QuestsViewModel _questsViewModel;

        public static QuestsViewModel QuestsViewModel
        {
            get
            {
                if (_questsViewModel == null)
                    _questsViewModel = new QuestsViewModel();
                return _questsViewModel;
            }
        }

    }
}
