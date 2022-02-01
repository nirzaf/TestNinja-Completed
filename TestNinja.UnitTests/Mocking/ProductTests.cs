using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product {ListPrice = 100};

            var result = product.GetPrice(new Customer {IsGold = true});
            
            Assert.That(result, Is.EqualTo(70));
        } 
        
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);
            
            var product = new Product {ListPrice = 100};

            var result = product.GetPrice(customer.Object);
            
            Assert.That(result, Is.EqualTo(70));
        }
        
    }
}