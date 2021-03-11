using System;
using System.Collections.Generic;
using System.Text;
using QuestArc.Models;
using ViewModels;

namespace QuestArc.ViewModels
{
    public class QuestViewModel : NotificationBase
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public Boolean AllDay { get; set; }
	}
}
