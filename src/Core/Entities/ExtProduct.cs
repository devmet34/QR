namespace Core.Entities
{
  public class ExtProduct
  {
    public ExtProduct(int id, string title, string description, decimal price, float rating, int stock)
    {
      Id = id;
      Title = title;
      Description = description;
      Price = price;
      Rating = rating;
      Stock = stock;
    }

    public int Id { get; private set; }
    public int ExtProductId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public float Rating { get; private set; }
    public int Stock { get; private set; }



  }
}
