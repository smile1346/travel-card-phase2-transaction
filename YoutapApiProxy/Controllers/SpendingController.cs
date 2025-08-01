using Microsoft.AspNetCore.Mvc;
using TransactionService.DTOs;
using TransactionService.Models;
using TransactionService.Services;

namespace TransactionService.Controllers
{
    [ApiController]
    [Route("api/transactions/[controller]")]
    public class SpendingController : ControllerBase
    {
        private readonly ISpendingService _spendingService;

        public SpendingController(ISpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        [HttpPost]
        public async Task<ActionResult<SpendingResponse>> CreateSpending([FromBody] CreateSpendingRequest request)
        {
            try
            {
                var spending = await _spendingService.CreateSpendingAsync(request);
                return CreatedAtAction(nameof(GetSpending), new { id = spending.Id }, spending);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpendingResponse>> GetSpending(Guid id)
        {
            var spending = await _spendingService.GetSpendingByIdAsync(id);
            return spending != null ? Ok(spending) : NotFound();
        }

        [HttpGet("trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<SpendingResponse>>> GetSpendingsByTrip(Guid tripId)
        {
            var spendings = await _spendingService.GetSpendingsByTripIdAsync(tripId);
            return Ok(spendings);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<SpendingResponse>>> GetSpendingsByCustomer(string customerId)
        {
            var spendings = await _spendingService.GetSpendingsByCustomerIdAsync(customerId);
            return Ok(spendings);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SpendingResponse>> UpdateSpending(Guid id, [FromBody] CreateSpendingRequest request)
        {
            try
            {
                var spending = await _spendingService.UpdateSpendingAsync(id, request);
                return Ok(spending);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [HttpPatch("{id}/status")]
        // public async Task<ActionResult<SpendingResponse>> UpdateSpendingStatus(Guid id, [FromBody] UpdateTransactionStatusRequest request)
        // {
        //     try
        //     {
        //         var spending = await _spendingService.UpdateSpendingStatusAsync(id, request.Status);
        //         return Ok(spending);
        //     }
        //     catch (ArgumentException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpending(Guid id)
        {
            await _spendingService.DeleteSpendingAsync(id);
            return NoContent();
        }

        [HttpGet("trip/{tripId}/summary")]
        public async Task<ActionResult<TransactionSummaryResponse>> GetTripSummary(Guid tripId)
        {
            var summary = await _spendingService.GetTripSummaryAsync(tripId);
            return Ok(summary);
        }
    }

    // [ApiController]
    // [Route("api/transactions/[controller]")]
    // public class WithdrawalController : ControllerBase
    // {
    //     private readonly ICashWithdrawalService _withdrawalService;

    //     public WithdrawalController(ICashWithdrawalService withdrawalService)
    //     {
    //         _withdrawalService = withdrawalService;
    //     }

    //     [HttpPost]
    //     public async Task<ActionResult<CashWithdrawalResponse>> CreateWithdrawal([FromBody] CreateCashWithdrawalRequest request)
    //     {
    //         try
    //         {
    //             var withdrawal = await _withdrawalService.CreateWithdrawalAsync(request);
    //             return CreatedAtAction(nameof(GetWithdrawal), new { id = withdrawal.Id }, withdrawal);
    //         }
    //         catch (ArgumentException ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<CashWithdrawalResponse>> GetWithdrawal(Guid id)
    //     {
    //         var withdrawal = await _withdrawalService.GetWithdrawalByIdAsync(id);
    //         return withdrawal != null ? Ok(withdrawal) : NotFound();
    //     }

    //     [HttpGet("trip/{tripId}")]
    //     public async Task<ActionResult<IEnumerable<CashWithdrawalResponse>>> GetWithdrawalsByTrip(Guid tripId)
    //     {
    //         var withdrawals = await _withdrawalService.GetWithdrawalsByTripIdAsync(tripId);
    //         return Ok(withdrawals);
    //     }

    //     [HttpGet("customer/{customerId}")]
    //     public async Task<ActionResult<IEnumerable<CashWithdrawalResponse>>> GetWithdrawalsByCustomer(string customerId)
    //     {
    //         var withdrawals = await _withdrawalService.GetWithdrawalsByCustomerIdAsync(customerId);
    //         return Ok(withdrawals);
    //     }

    //     [HttpPut("{id}")]
    //     public async Task<ActionResult<CashWithdrawalResponse>> UpdateWithdrawal(Guid id, [FromBody] CreateCashWithdrawalRequest request)
    //     {
    //         try
    //         {
    //             var withdrawal = await _withdrawalService.UpdateWithdrawalAsync(id, request);
    //             return Ok(withdrawal);
    //         }
    //         catch (ArgumentException ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpPatch("{id}/status")]
    //     public async Task<ActionResult<CashWithdrawalResponse>> UpdateWithdrawalStatus(Guid id, [FromBody] UpdateTransactionStatusRequest request)
    //     {
    //         try
    //         {
    //             var withdrawal = await _withdrawalService.UpdateWithdrawalStatusAsync(id, request.Status);
    //             return Ok(withdrawal);
    //         }
    //         catch (ArgumentException ex)
    //         {
    //             return BadRequest(ex.Message);
    //         }
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> DeleteWithdrawal(Guid id)
    //     {
    //         await _withdrawalService.DeleteWithdrawalAsync(id);
    //         return NoContent();
    //     }
    // }
}