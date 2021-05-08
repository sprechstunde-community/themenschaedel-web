using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Themenschaedel.Shared.Props;

namespace Themenschaedel.Web.Services.Interfaces
{
    public interface IData
    {
        Task<GetEpisodeWorkaround> GetEpisodes(int count, int page);
        Task<Episode> GetEpisode(int id);
        Task<string> Login(string email, string password);
    }
}
