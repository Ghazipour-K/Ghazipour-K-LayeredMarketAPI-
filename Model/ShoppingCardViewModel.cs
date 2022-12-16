using System;

namespace Market.Model
{
    public class ShoppingCardViewModel
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int DeliveryScheduleID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchasedDate { get; set; }
    }
}