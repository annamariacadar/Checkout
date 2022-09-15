using Checkout.Api.Requests;
using Checkout.Api.Responses;
using Checkout.Application.Query;
using Checkout.Command.Contracts;
using Checkout.Commands;
using Checkout.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Checkout.Api.Controllers
{
    [Route("baskets/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketApplication _basketApplication;
        private readonly ICreateBasketCommand _createBasketCommand;
        private readonly IAddArticleCommand _addArticleCommand;
        private readonly ICloseBasketCommand _closeBasketCommand;
        public BasketsController(IBasketApplication basketApplication, ICreateBasketCommand createBasketCommand, IAddArticleCommand addArticleCommand, ICloseBasketCommand closeBasketCommand)
        {
            _basketApplication = basketApplication;
            _createBasketCommand = createBasketCommand;
            _addArticleCommand = addArticleCommand;
            _closeBasketCommand = closeBasketCommand;
        }

        /// <summary>
        /// Creates basket
        /// </summary>
        /// <param name="basketRequest"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BasketRequest))]

        public async Task<IActionResult> Post(BasketRequest basketRequest)
        {
            var createBasketCommandEntry = new CreateBasketCommandEntry() { Customer = basketRequest.Customer, PaysVAT = basketRequest.PaysVat };
            var id = await _createBasketCommand.Execute(createBasketCommandEntry);
            return Ok(id);
        }

        /// <summary>
        /// Updates basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="articleRequest"></param>
        /// <returns></returns>
        [HttpPut("/{basketId}/article-line")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleRequest))]
        public async Task<IActionResult> Put([FromRoute] int basketId, ArticleRequest articleRequest)
        {
            var addArticleCommandEntry = new AddArticleCommandEntry() { BasketId = basketId, Item = articleRequest.Item, Price = articleRequest.Price };
            await _addArticleCommand.Execute(addArticleCommandEntry);
            return Ok();
        }

        /// <summary>
        /// Gets a basket by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketResponse))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var basket = await _basketApplication.GetBasketAsync(id);

                var basketResponse = new BasketResponse()
                {
                    Articles = basket.Articles.Select(e => new ArticleResponse() { Id = e.Id, Price = e.Price, Item = e.Item }).AsEnumerable(),
                    Customer = basket.Customer,
                    Id = basket.Id,
                    Payed = basket.Payed,
                    Close = basket.Close,
                    PaysVat = basket.PaysVat,
                    TotalGross = basket.TotalGross,
                    TotalNet = basket.TotalNet
                };

                return Ok(basketResponse);
            }
            catch (BasketNotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Closes a basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="closeBasketRequest"></param>
        /// <returns></returns>
        [HttpPatch("/{basketId}")]
        public async Task<IActionResult> Patch([FromRoute] int basketId, CloseBasketRequest closeBasketRequest)
        {
            try
            {
                await _closeBasketCommand.Execute(new CloseBasketCommandEntry() { BasketId = basketId, Close = closeBasketRequest.Close, Payed = closeBasketRequest.Payed });
                return Ok();
            }
            catch (BasketNotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
