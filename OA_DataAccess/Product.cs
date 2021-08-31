using System;
using System.Collections.Generic;
using System.Text;

namespace OA_DataAccess
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Details { get; set; }

        public int StockAvailable { get; set; }
    }
}
