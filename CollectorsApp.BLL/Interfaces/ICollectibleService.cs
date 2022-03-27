using CollectorsApp.BLL.DataTransferObjects;
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
        Task<IEnumerable<CollectibleDto>> GetCollectiblesAsync();
        Task<IEnumerable<CollectibleDto>> GetCollectiblesForSaleAsync();
        Task<CollectibleDto> GetCollectibleAsync(int id);
        Task AddCollectibleAsync(CollectibleDto collectible);
        Task UpdateColletctibleAsync(int id, CollectibleDto collectible);
        Task DeleteCollectibleAsync(int id);
        

    }
}
