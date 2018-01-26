using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<DateList> GetAllHearEvents();
        Events.Jazz GetHearEvent(int? id);
        void UpdateHearEvent(Events.Jazz festivalEvent);
        List<Location> GetHearLocations();

        List<DateList> GetAllTasteEvents();
        Events.Diner GetTasteEvent(int? id);
        void UpdateTasteEvent(Events.Diner festivalEvent);
        List<Restaurant> GetTasteLocations();

        List<DateList> GetAllSeeEvents();
        Events.Historic GetSeeEvent(int? id);
        void UpdateSeeEvent(Events.Historic festivalEvent);
        List<Location> GetSeeLocations();

        List<DateList> GetAllTalkEvents();
        Events.Talk GetTalkEvent(int? id);
        void UpdateTalkEvent(Events.Talk festivalEvent);
        List<Location> GetTalkLocations();

        List<SalesItem> GetAllEvents();
        int GetTotalSales();
        double GetTotalRevenue();
    }
}