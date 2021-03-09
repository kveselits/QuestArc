using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QuestArc.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class Quest
    {
       

        

        [PrimaryKey, AutoIncrement]
        public long QuestId { get; set; }
        [Indexed]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public bool AllDay { get; set; }

        public Status Status { get; set; }

        public string ShortDescription => $"Quest ID: {QuestId} - {Title}";
    }
}
