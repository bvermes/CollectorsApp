using AutoMapper;
using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL;
using CollectorsApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Services
{
    public class TeamsService : ITeamService
    {
        private readonly CollectorsAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TeamsService(CollectorsAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            var teams = await _dbContext.Teams.ToListAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }


        public async Task AddTeamAsync(TeamDto team)
        {

            await _dbContext.Teams.AddAsync(_mapper.Map<Team>(team));
            await _dbContext.SaveChangesAsync();
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
