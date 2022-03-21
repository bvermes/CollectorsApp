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
    public class CollectibleService : ICollectibleService
    {
        private readonly CollectorsAppDbContext _dbContext;
        public CollectibleService(CollectorsAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Collectible> GetCollectibles()
        {
            return _dbContext.Collection.ToList();
        }
        public void AddCollectible(Collectible collectible)
        {
            _dbContext.Collection.Add(collectible);
            _dbContext.SaveChanges();
        }

        public Collectible GetCollectible(int id)
        {
            return _dbContext.Collection.Where(w => w.Id == id).First();
        }

        public void UpdateColletctible(int id, Collectible collectible)
        {
            collectible.Id = id;
            _dbContext.Update(collectible);
            _dbContext.SaveChanges();
        }

        public void DeleteCollectible(int id)
        {
            var collectible= GetCollectible(id);

            _dbContext.Collection.Remove(collectible);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Collectible> GetCollectiblesForSale()
        {
            var list = _dbContext.Collection.Where(w => w.ForSale == true).ToList();
            return list;
        }
    }
}
