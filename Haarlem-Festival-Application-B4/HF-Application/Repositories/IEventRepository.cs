using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        List<HearDateList> GetAllHearEvents();
        FestivalEvent GetEvent(int id);
    }
}