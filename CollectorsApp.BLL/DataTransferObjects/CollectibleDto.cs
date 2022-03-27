﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.DataTransferObjects
{
    public class CollectibleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoughtFor { get; set; }
        public int Value { get; set; }
        public bool ForSale { get; set; }
    }
}