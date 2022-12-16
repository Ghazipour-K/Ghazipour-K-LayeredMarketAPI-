namespace Market.Controller
{
    public class DeleteItemFromShoppingCardCommand
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
    }
}