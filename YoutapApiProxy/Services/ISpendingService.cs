using TransactionService.DTOs;

namespace TransactionService.Services
{
    public interface ISpendingService
    {
        Task<SpendingResponse> CreateSpendingAsync(CreateSpendingRequest request);
        Task<SpendingResponse?> GetSpendingByIdAsync(Guid id);
        Task<IEnumerable<SpendingResponse>> GetSpendingsByTripIdAsync(Guid tripId);
        Task<IEnumerable<SpendingResponse>> GetSpendingsByCustomerIdAsync(string customerId);
        Task<SpendingResponse> UpdateSpendingAsync(Guid id, CreateSpendingRequest request);
        // Task<SpendingResponse> UpdateSpendingStatusAsync(Guid id);
        Task DeleteSpendingAsync(Guid id);
        Task<TransactionSummaryResponse> GetTripSummaryAsync(Guid tripId);
    }

    // public interface ICashWithdrawalService
    // {
    //     Task<CashWithdrawalResponse> CreateWithdrawalAsync(CreateCashWithdrawalRequest request);
    //     Task<CashWithdrawalResponse?> GetWithdrawalByIdAsync(Guid id);
    //     Task<IEnumerable<CashWithdrawalResponse>> GetWithdrawalsByTripIdAsync(Guid tripId);
    //     Task<IEnumerable<CashWithdrawalResponse>> GetWithdrawalsByCustomerIdAsync(string customerId);
    //     Task<CashWithdrawalResponse> UpdateWithdrawalAsync(Guid id, CreateCashWithdrawalRequest request);
    //     Task<CashWithdrawalResponse> UpdateWithdrawalStatusAsync(Guid id);
    //     Task DeleteWithdrawalAsync(Guid id);
    // }
}