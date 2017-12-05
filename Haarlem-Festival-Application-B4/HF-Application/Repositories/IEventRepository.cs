using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<HearDateList> GetAllHearEvents();
        Events.Jazz GetHearEvent(int id);
    }
}