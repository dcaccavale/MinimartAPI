﻿namespace Entities
{
    public class StockProduct : Entity
    {
        public Store Store { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}