using System;

namespace QuestArc.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class Quest
    {
        public long QuestId { get; set; }

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
