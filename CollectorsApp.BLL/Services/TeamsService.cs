using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL;
using CollectorsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly CollectorsAppDbContext _dbContext;

        public TeamsService(CollectorsAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTeam(Team team)
        {
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Team> GetTeams()
        {
            return _dbContext.Teams.ToList();
        }

        public void RemoveTeam()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam()
        {
            throw new NotImplementedException();
        }
    }
}
