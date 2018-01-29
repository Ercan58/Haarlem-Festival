using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Events;
using HF_Application.Models;

namespace HF_Application.Interface
{
    public interface IHomeRepository
    {
        List<Jazz> jazzList();
        List<Restaurant> restoList();
        List<Talk> talkList();

    }
}