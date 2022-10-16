using System;

namespace Market.Controller
{
    public class DeleteShoppingCardItemDTO
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public string DeliveryScheduleID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchasedDate { get; set; }
    }
}