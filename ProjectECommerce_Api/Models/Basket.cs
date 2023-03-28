namespace ProjectECommerce_Api.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int TotalPrice { get; set; }
         
        private List<Product> products = new List<Product>();
        public void Add(Product product)
        {
            if (product != null)
                products.Add(product);
        }
        public double KdvliFiyat(int adet)
        {
            double totalPrice = 0;
            foreach (Product product in products)
            {
                double kdvli = product.Price*2;
                double basketPrice=adet*kdvli;
                totalPrice += basketPrice;
            }
            return totalPrice;
        }
        public Basket(int basketId, int totalPrice)
        {
            BasketId = basketId;
            TotalPrice = totalPrice;
         
        }
        public Basket() { }
    }
}
