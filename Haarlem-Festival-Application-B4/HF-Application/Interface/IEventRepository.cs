using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<DateList> GetAllHearEvents();
        Events.Jazz GetHearEvent(int id);
        void UpdateHearEvent(Events.Jazz festivalEvent);
        List<DateList> GetAllTasteEvents();
        Events.Diner GetTasteEvent(int id);
        void UpdateTasteEvent(Events.Diner festivalEvent);

        List<Location> GetHearLocations();
    }
}