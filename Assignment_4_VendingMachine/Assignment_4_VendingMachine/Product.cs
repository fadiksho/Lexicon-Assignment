using System;

namespace Assignment_4_VendingMachine
{
  public abstract class Product : IProduct
  {
    public int Id { get; }

    public string Name { get; }

    public int Price { get; set; }

    public static int ProductsCount { get; private set; }

    public Product(int id, string name)
    {
      this.Id = id;
      this.Name = name;

      ProductsCount += 1;
    }

    public virtual void DisplayProductInfo()
    {
      Console.WriteLine($"Name: {Name, -15} | Price: {Price, -3} kr | Id: {Id}");
    }

    public abstract void UseProduct();
  }
}
