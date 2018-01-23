using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Interface
{
    interface ICartRepository
    {
        List<OrderItem> Additem(int itemid, int aantal, string Question, FestivalEvent orderitem);
        FestivalEvent GetbesteldEvent(int eventid);
    }
}
