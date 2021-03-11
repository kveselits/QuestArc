using System;
using System.Collections.Generic;

namespace QuestArc.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.

    public class Arc
    {
        public long ArcId { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public string Difficulty { get; set; }
        
        public string Status { get; set; }

        //TODO: What's this do?
        public char Symbol => (char)SymbolCode;

        public int SymbolCode { get; set; }

        public ICollection<Quest> Quests { get; set; }

        public override string ToString()
        {
            return $"{Title} {Status}";
        }

        public string ShortDescription => $"Arc ID: {ArcId}";
    }
}
