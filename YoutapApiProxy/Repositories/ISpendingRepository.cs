using TransactionService.Models;

namespace TransactionService.Repositories
{
    public interface ISpendingRepository
    {
        Task<Spending?> GetByIdAsync(Guid id);
        Task<IEnumerable<Spending>> GetByTripIdAsync(Guid tripId);
        Task<IEnumerable<Spending>> GetByCustomerIdAsync(string customerId);
        Task<IEnumerable<Spending>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<Spending> CreateAsync(Spending spending);
        Task<Spending> UpdateAsync(Spending spending);
        Task DeleteAsync(Guid id);
    }

    // public interface ICashWithdrawalRepository
    // {
    //     Task<CashWithdrawal?> GetByIdAsync(Guid id);
    //     Task<IEnumerable<CashWithdrawal>> GetByTripIdAsync(Guid tripId);
    //     Task<IEnumerable<CashWithdrawal>> GetByCustomerIdAsync(string customerId);
    //     Task<IEnumerable<CashWithdrawal>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
    //     Task<CashWithdrawal> CreateAsync(CashWithdrawal withdrawal);
    //     Task<CashWithdrawal> UpdateAsync(CashWithdrawal withdrawal);
    //     Task DeleteAsync(Guid id);
    // }
}