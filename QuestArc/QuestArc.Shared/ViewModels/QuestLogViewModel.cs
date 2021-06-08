using System;
using QuestArc.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using QuestArc.Models;

namespace QuestArc.ViewModels
{
    public class QuestLogViewModel : ObservableObject
    {
        public SQLiteDatabase Db = App.Database;

        public QuestLogViewModel()
        {
            
        }

    }
}
