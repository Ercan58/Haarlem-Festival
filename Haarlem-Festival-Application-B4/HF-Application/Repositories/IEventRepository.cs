using System.Collections.Generic;

namespace HF_Application.Models
{
    public interface IEventRepository
    {
        IEnumerable<FestivalEvent> GetAllEvents();
        FestivalEvent GetEvent(int id);
    }
}