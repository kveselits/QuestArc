using System;
using System.Collections.Generic;
using System.Text;

namespace QuestArc.Models
{
    class QuestInfoSampleData
    {

        public static IEnumerable<QuestInfo> GetSampleData()
        {
            return new QuestInfo[]
            {
                new QuestInfo()
                {
                    ID = "1",
                    Description = "Go to school",
                },
                new QuestInfo()
                {
                    ID = "2",
                    Description = "Go to mall",
                },
                new QuestInfo()
                {
                    ID = "3",
                    Description = "Go to moon",
                },
            };
        }
    }

internal class QuestInfo
{
    public string ID { get; internal set; }
    public string Description { get; set; }
}
}
