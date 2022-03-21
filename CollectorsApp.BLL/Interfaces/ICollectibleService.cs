using CollectorsApp.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.Interfaces
{
    public interface ICollectibleService
    {
        IEnumerable<Collectible> GetCollectibles();
        IEnumerable<Collectible> GetCollectiblesForSale();
        Collectible GetCollectible(int id);
        void AddCollectible(Collectible collectible);
        void UpdateColletctible(int id, Collectible collectible);
        void DeleteCollectible(int id);
    }
}
