using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HF_Application.Models.Events;
using HF_Application.Models;

namespace HF_Application.Interface
{
    interface ITalkRepository
    {
        List<Talk> GetAllTalkEvents();
        List<Talk> GetTalkEvents(DateTime date);
        Talk GetCurrentTalkEvent(int id);
        List<Talk> GetCrossTalkEvents(int id);




    }
}
