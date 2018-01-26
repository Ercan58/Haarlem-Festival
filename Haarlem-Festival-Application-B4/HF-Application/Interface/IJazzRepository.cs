using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Events;
using HF_Application.Models;

namespace HF_Application.Repositories
{
    public interface IJazzRepository
    {
        List<Jazz> GetAllJazzEvents();
        List<Jazz> GetJazzEvents(DateTime date);
        Jazz GetJazzEventById(int id);
        List<Restaurant> CrossSellingRestaurauntList();
    }
}