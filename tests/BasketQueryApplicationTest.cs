using Checkout.Application.Query;
using Checkout.Repository;
using Checkout.Repository.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BasketQueryApplicationTest
    {
        private  Mock<IBasketRepository> _basketRepositoryMock;
        private BasketApplication _sut;

        public BasketQueryApplicationTest()
        {
            _basketRepositoryMock = new Mock<IBasketRepository>();
            _sut = new BasketApplication(_basketRepositoryMock.Object);
        }


        [Fact]
        public async Task GetBasketAsyncTest()
        {
            //Arrage
            var articles = new List<Article>();
            var article1 = new Article { Id=1, Item="tomato",Price=20};
            articles.Add(article1);
            var article2 = new Article { Id = 2, Item = "juice", Price = 10 };
            articles.Add(article2);
            var basket = new Basket {Id=1, Articles=articles,Payed=true,PaysVat=true};
            _basketRepositoryMock.Setup(e=>e.GetBasketAsync(1)).ReturnsAsync(basket);

            //Act
           var basketDomain= await _sut.GetBasketAsync(1);
            //Assert
           Assert.Equal(30,basketDomain.TotalNet);
           Assert.Equal(33,basketDomain.TotalGross);
            

        }
    }
}