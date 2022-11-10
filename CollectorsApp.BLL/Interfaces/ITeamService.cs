using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();
        Task AddTeamAsync(TeamDto team);
        void RemoveTeam();
        void UpdateTeam();
    }
}
