using System;

namespace Market.Model
{
    public class ShoppingCardViewModel
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public string DeliveryScheduleID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchasedDate { get; set; }
    }
}