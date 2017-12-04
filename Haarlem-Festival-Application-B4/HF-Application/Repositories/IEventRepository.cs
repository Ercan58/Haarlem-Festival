using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        IEnumerable<HearDateList> GetAllHearEvents();
        FestivalEvent GetEvent(int id);
    }
}