using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HF_Application.Models.Events;
using HF_Application.Models;


namespace HF_Application.Interface
{
    interface IHistoricRepository
    {
       List<Historic> GetAllHistoryEvents();
       List<Historic> GetHistoricEvents(DateTime datetime);
       Historic GetJazzEventById(int id);
    }
}
