using Checkout.Api.Controllers;
using Checkout.Api.Responses;
using Checkout.Application.Query;
using Commands;
using FluentAssertions;
using Moq;
using Xunit;

namespace CheckoutTests
{
    [Trait("baskets", "GetBasket")]
    public class BasketControllerTests
    {
        private Mock<IBasketApplication> _basketApplicationMock;
        private Mock<ICreateBasketCommand> _createBasketCommandMock;
        private Mock<IAddArticleCommand> _addArticleCommandMock;
        private Mock<ICloseBasketCommand> _closeBasketCommandMock;
        private BasketsController _sut;

        private void TestInitialize()
        {
            _basketApplicationMock = new Mock<IBasketApplication>();
            _createBasketCommandMock = new Mock<ICreateBasketCommand>();
            _addArticleCommandMock = new Mock<IAddArticleCommand>();
            _closeBasketCommandMock = new Mock<ICloseBasketCommand>();

            _sut = new BasketsController(_basketApplicationMock.Object, _createBasketCommandMock.Object, _addArticleCommandMock.Object, _closeBasketCommandMock.Object);

        }

        [Fact]
        public async Task CreateBasketTest()
        {
            // Arrange
            TestInitialize();
            _basketApplicationMock.Setup(m => m.GetBasketAsync(It.IsAny<int>())).ReturnsAsync(new Checkout.Common.Basket { Id = 1 });

            // Act
            var result = await _sut.Get(1);

            // Assert
            result.Should().BeOfType<BasketResponse>();
            _basketApplicationMock.Verify(e => e.GetBasketAsync(It.IsAny<int>()), Times.Once());
        }

    }
}
