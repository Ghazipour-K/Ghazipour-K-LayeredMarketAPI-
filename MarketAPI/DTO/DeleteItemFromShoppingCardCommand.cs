namespace Market.Controller
{
    public class DeleteItemFromShoppingCardCommand
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
    }
}