using System;
using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<DateList> GetAllHearEvents();
        Events.Jazz GetHearEvent(int? id);
        void AddHearEvent(Events.Jazz festivalEvent);
        void UpdateHearEvent(Events.Jazz festivalEvent);
        List<Location> GetHearLocations();

        List<DateList> GetAllTasteEvents();
        Events.Diner GetTasteEvent(int? id);
        void AddTasteEvent(Events.Diner festivalEvent);
        void UpdateTasteEvent(Events.Diner festivalEvent);
        List<Restaurant> GetTasteLocations();
        Restaurant GetRestaurant(int id);

        List<DateList> GetAllSeeEvents();
        Events.Historic GetSeeEvent(int? id);
        void AddSeeEvent(Events.Historic festivalEvent);
        void UpdateSeeEvent(Events.Historic festivalEvent);
        List<Location> GetSeeLocations();

        List<DateList> GetAllTalkEvents();
        Events.Talk GetTalkEvent(int? id);
        void AddTalkEvent(Events.Talk festivalEvent);
        void UpdateTalkEvent(Events.Talk festivalEvent);
        List<Location> GetTalkLocations();
        List<TalkQuestion> GetAllTalkQuestions();

        Location GetLocation(int id);
        List<SalesItem> GetAllEvents();
        List<SalesItem> GetAllEvents(DateTime dateTime);
        int GetTotalSales();
        int GetTotalSales(DateTime dateTime);
        double GetTotalRevenue();
        double GetTotalRevenue(DateTime dateTime);

        void Dispose();
    }
}