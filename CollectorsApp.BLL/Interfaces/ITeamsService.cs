using CollectorsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Interfaces
{
    public interface ITeamsService
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
        void RemoveTeam();
        void UpdateTeam();
    }
}
