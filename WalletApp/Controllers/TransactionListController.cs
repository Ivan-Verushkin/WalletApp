using WalletAppApi.Dtos;
using WalletAppApi.Mappers;
using WalletAppApi.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace WalletAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionListController : ControllerBase
    {
        private readonly ITransactionListRepository _transactionListRepository;

        public TransactionListController(ITransactionListRepository transactionListRepository)
        {
            _transactionListRepository = transactionListRepository;
        }

        /// <summary>
        /// Get Transaction List by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TransactionListDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TransactionListDto>> GetTransactionListByUserId([FromRoute] int id) 
        {
            var list = await _transactionListRepository.GetTransactionListByUserIdAsync(id);

            if (list == null)
            {
                return NotFound($"There is no Transaction list for userId = {id}");
            }

            return Ok(list.ToTransactionListDto());
        }
    }
}
