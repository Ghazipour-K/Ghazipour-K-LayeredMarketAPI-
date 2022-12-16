using System;

namespace Market.Controller
{
    public class AddItemToShoppingCardCommand
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int DeliveryScheduleID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchasedDate { get; set; }
    }
}