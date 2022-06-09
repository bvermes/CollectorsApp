using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CollectorsApp.DAL.Entities
{
    public class Collectible
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoughtFor { get; set; }
        public int Value { get; set; }
        public int SellingPrice { get; set; }
        public bool ForSale { get; set; }
        public bool Sold { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        //[NotMapped]
        //public string ImageSrc { get; set; }

    }
}
