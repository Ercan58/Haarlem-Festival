using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class DateList
    {
        public string Date;
        public List<Events.Diner> TasteList;
        public List<Events.Jazz> HearList;
        public List<Events.Talk> TalkList;
        public List<Events.Historic> SeeList;

        public DateList(string date, List<Events.Diner> tasteList)
        {
            Date = date;
            TasteList = tasteList;
        }

        public DateList(string date, List<Events.Jazz> hearList)
        {
            Date = date;
            HearList = hearList;
        }

        public DateList(string date, List<Events.Talk> talkList)
        {
            Date = date;
            TalkList = talkList;
        }

        public DateList(string date, List<Events.Historic> seeList)
        {
            Date = date;
            SeeList = seeList;
        }
    }
}