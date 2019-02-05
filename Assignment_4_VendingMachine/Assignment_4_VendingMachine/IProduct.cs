using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public interface IProduct
  {
    int Id { get; }
    string Name { get; }
    int Price { get; set; }

    void UseProduct();
    void DisplayProductInfo();
  }
}
