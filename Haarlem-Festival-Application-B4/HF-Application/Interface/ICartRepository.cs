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
        List<OrderItem> Additem(int itemid, int aantal, string Question, FestivalEvent festivalEvent, int prijs);
        List<OrderItem> Additemzonderevent(int itemid, int aantal, string Question, int prijs);

        FestivalEvent GetbesteldEvent(int eventid);

        int PlaceOrder(int userid);
        int SaveOrder(int userid);
        void Additemsdb(OrderItem item);
    }
}
