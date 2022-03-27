using AutoMapper;
using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.BLL.Exceptions;
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
    public class CollectibleService : ICollectibleService
    {
        private readonly CollectorsAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CollectibleService(CollectorsAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CollectibleDto>> GetCollectiblesAsync()
        {
            var collectibles = await _dbContext.Collection.ToListAsync();

            return _mapper.Map<IEnumerable<CollectibleDto>>(collectibles);
        }
        public async Task AddCollectibleAsync(CollectibleDto collectible)
        {
            var mappedCollectible = _mapper.Map<Collectible>(collectible);

            await _dbContext.Collection.AddAsync(mappedCollectible);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CollectibleDto> GetCollectibleAsync(int id)
        {
            var collectible = await _dbContext.Collection
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync() ?? throw new EntityNotFoundException("Nincs ilyen elem!");

            return _mapper.Map<CollectibleDto>(collectible);
        }

        public async Task UpdateColletctibleAsync(int id, CollectibleDto collectible)
        {
            collectible.Id = id;

            _dbContext.Update(_mapper.Map<CollectibleDto>(collectible));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCollectibleAsync(int id)
        {
            var collectible = GetCollectibleAsync(id);
            var mappedCollectible = _mapper.Map<Collectible>(collectible);

            _dbContext.Collection.Remove(mappedCollectible);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollectibleDto>> GetCollectiblesForSaleAsync()
        {
            var list = await _dbContext.Collection.Where(w => w.ForSale == true).ToListAsync();
            return _mapper.Map<IEnumerable<CollectibleDto>>(list);
        }
    }
}
