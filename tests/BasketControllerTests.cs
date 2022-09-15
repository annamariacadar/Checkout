using Checkout.Api.Controllers;
using Checkout.Api.Requests;
using Checkout.Application.Query;
using Checkout.Command.Contracts;
using Checkout.Commands;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutTests
{
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
            _basketApplicationMock.Verify(e => e.GetBasketAsync(It.IsAny<int>()), Times.Once());
        }


        [Fact]
        public async Task AddArticleToBasketTest()
        {
            // Arrange
            TestInitialize();
            var articleRequest = new ArticleRequest();
            // Act
            var result = await _sut.Put(1, articleRequest);

            // Assert
            _addArticleCommandMock.Verify(e => e.Execute(It.IsAny<AddArticleCommandEntry>()), Times.Once());
        }

        [Fact]
        public async Task CloseBasketTest()
        {
            // Arrange
            TestInitialize();
            var closeBasketRequest = new CloseBasketRequest();
            // Act
            var result = await _sut.Patch(1, closeBasketRequest);

            // Assert
            _closeBasketCommandMock.Verify(e => e.Execute(It.IsAny<CloseBasketCommandEntry>()), Times.Once());
        }

    }
}
