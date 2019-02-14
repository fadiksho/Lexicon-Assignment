using Assignment_4_VendingMachine;
using System.Collections.Generic;
using Xunit;

namespace Assignment_4_VendingMachine_Test
{
  public class VendingMachine_Test
  {
    [Fact]
    public void GetProductByIdSetTheSelectedProductProperty()
    {
      // Arrange
      var vendingMaching = new VendingMachine(new List<Product>
      {
        new Fruits("Apple") { Price = 24 },
        new Staple("Baguette") { Price = 20 },
        new Dessert("Ice Cream") { Price = 40 },
      });
      // Act
      vendingMaching.SelectProduct(1);
      // Assert
      Assert.NotNull(vendingMaching.SelectedProductToBuy);
    }

    [Fact]
    public void BuyingProductShouldSetTheSelectedProductPropertyToNull()
    {
      // Arrange
      var vendingMaching = new VendingMachine(new List<Product>
     {
        new Fruits("Apple") { Price = 24 },
        new Staple("Baguette") { Price = 20 },
        new Dessert("Ice Cream") { Price = 40 },
     })
      {
        MonyPool = 50
      };
      // Act
      vendingMaching.SelectProduct(1);
      vendingMaching.BuyProduct();
      // Assert
      Assert.Null(vendingMaching.SelectedProductToBuy);
    }

    [Fact]
    public void BuyingProductShouldReduceTheUserMonyPool()
    {
      // Arrange
      var vendingMaching = new VendingMachine(new List<Product>
     {
        new Fruits("Apple") { Price = 24 },
        new Staple("Baguette") { Price = 20 },
        new Dessert("Ice Cream") { Price = 40 },
     });
      vendingMaching.MonyPool = 50;
      // Act
      vendingMaching.SelectProduct(1);
      vendingMaching.BuyProduct();
      // Assert
      Assert.True(vendingMaching.MonyPool < 50);
    }

    [Fact]
    public void UserCanNotBuyWhenDontHaveMonyForTheSelectedProduct()
    {
      // Arrange
      var vendingMaching = new VendingMachine(new List<Product>
     {
        new Fruits("Apple") { Price = 24 },
        new Staple("Baguette") { Price = 20 },
        new Dessert("Ice Cream") { Price = 40 },
     })
      {
        MonyPool = 0
      };
      // Act
      vendingMaching.SelectProduct(1);
      // Assert
      Assert.False(vendingMaching.CanBuySelectedProduct);
    }
  }
}
