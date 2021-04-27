using System;
using QuestArc.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;

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
