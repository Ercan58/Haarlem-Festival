using System.Collections.Generic;

namespace HF_Application.Models.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<FestivalEvent> GetAllEvents();
    }
}