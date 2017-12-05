using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<HearDateList> GetAllHearEvents();
        Events.Jazz GetHearEvent(int id);
        void UpdateHearEvent(Events.Jazz festivalEvent);
        List<TasteDateList> GetAllTasteEvents();
        Events.Diner GetTasteEvent(int id);
        void UpdateTasteEvent(Events.Diner festivalEvent);

        List<Location> GetLocations();
    }
}