using WalletAppApi.Dtos;
using WalletAppApi.Mappers;
using WalletAppApi.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Api.Dtos;
using WalletAppApi.Models;

namespace WalletAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly IUserRepository _userRepository;

        public TransactionDetailController(ITransactionDetailRepository transactionDetailRepository, IUserRepository userRepository)
        {
            _transactionDetailRepository = transactionDetailRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get Transaction Detail Image by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTransactionDetailImage/{id}")]
        [ProducesResponseType(200, Type = typeof(PhysicalFileResult))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetTransactionDetailImageById(int id)
        {
            var details = await _transactionDetailRepository.GetTransactionDetailByDetailIdAsync(id);

            if(details == null)
            {
                return NotFound();
            }

            return new PhysicalFileResult(Environment.CurrentDirectory + details.ImagePath, "image/png");
        }

        /// <summary>
        /// Get Transaction Detail by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transactionDetailId"></param>
        /// <returns></returns>
        [HttpGet("{userId}/{transactionDetailId}")]
        [ProducesResponseType(200, Type = typeof(TransactionDetailDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TransactionDetailDto>> GetTransactionDetailByUserId(int userId, int transactionDetailId)
        {
            var details = await _transactionDetailRepository.GetTransactionDetailByUserIdAsync(userId, transactionDetailId);

            if(details == null)
            {
                return NotFound();
            }

            return Ok(details.ToTransactionDetailDto());
        }

        /// <summary>
        /// Create Transaction Detail by initializerUserId, destinationUserId and transactionDetail model. Affects a destination user Balance amount
        /// </summary>
        /// <param name="initializerUserId">The user who performed a transaction</param>
        /// <param name="destinationUserId">The user who is receiving a transaction</param>
        /// <param name="transactionDetailDto">Transaction detail model</param>
        /// <returns></returns>
        [HttpPost("{initializerUserId}/{destinationUserId}")]
        [ProducesResponseType(200, Type = typeof(TransactionDetailDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateTransaction([FromRoute] int initializerUserId, [FromRoute] int destinationUserId, [FromBody] CreateTransactionDetailDto transactionDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var transactionList = await _userRepository.GetUserTransactionListId(initializerUserId);

            var user = await _userRepository.GetUserById(destinationUserId);

            if (transactionList == null)
            {
                return BadRequest($"Can`t create a transaction because user hasn`t initialized his Transaction List");
            }

            
            try 
            {
                var transactionDetail = transactionDetailDto.ToTransactionDetailFromTransactionDetailDto(user, transactionList, initializerUserId, destinationUserId);

                var createdTransaction = await _transactionDetailRepository.CreateTransactionDetail(transactionDetail, destinationUserId);

                return Ok(createdTransaction.ToTransactionDetailDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
