using Microsoft.EntityFrameworkCore;
using TransactionService.Data;
using TransactionService.Models;

namespace TransactionService.Repositories
{
    public class SpendingRepository : ISpendingRepository
    {
        private readonly TransactionDbContext _context;

        public SpendingRepository(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<Spending?> GetByIdAsync(Guid id)
        {
            return await _context.Spendings.FindAsync(id);
        }

        public async Task<IEnumerable<Spending>> GetByTripIdAsync(Guid tripId)
        {
            return await _context.Spendings
                .Where(s => s.TripId == tripId)
                .OrderByDescending(s => s.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spending>> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Spendings
                .Where(s => s.CustomerId == customerId)
                .OrderByDescending(s => s.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Spending>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.Spendings
                .Where(s => s.DateTime >= fromDate && s.DateTime <= toDate)
                .OrderByDescending(s => s.DateTime)
                .ToListAsync();
        }

        public async Task<Spending> CreateAsync(Spending spending)
        {
            spending.Id = Guid.NewGuid();
            spending.CreatedAt = DateTime.UtcNow;
            spending.UpdatedAt = DateTime.UtcNow;
            spending.Status = TransactionStatus.Completed;

            _context.Spendings.Add(spending);
            await _context.SaveChangesAsync();
            return spending;
        }

        public async Task<Spending> UpdateAsync(Spending spending)
        {
            spending.UpdatedAt = DateTime.UtcNow;
            _context.Spendings.Update(spending);
            await _context.SaveChangesAsync();
            return spending;
        }

        public async Task DeleteAsync(Guid id)
        {
            var spending = await _context.Spendings.FindAsync(id);
            if (spending != null)
            {
                _context.Spendings.Remove(spending);
                await _context.SaveChangesAsync();
            }
        }
    }

    // public class CashWithdrawalRepository : ICashWithdrawalRepository
    // {
    //     private readonly TransactionDbContext _context;

    //     public CashWithdrawalRepository(TransactionDbContext context)
    //     {
    //         _context = context;
    //     }

    //     public async Task<CashWithdrawal?> GetByIdAsync(Guid id)
    //     {
    //         return await _context.CashWithdrawals.FindAsync(id);
    //     }

    //     public async Task<IEnumerable<CashWithdrawal>> GetByTripIdAsync(Guid tripId)
    //     {
    //         return await _context.CashWithdrawals
    //             .Where(w => w.TripId == tripId)
    //             .OrderByDescending(w => w.DateTime)
    //             .ToListAsync();
    //     }

    //     public async Task<IEnumerable<CashWithdrawal>> GetByCustomerIdAsync(string customerId)
    //     {
    //         return await _context.CashWithdrawals
    //             .Where(w => w.CustomerId == customerId)
    //             .OrderByDescending(w => w.DateTime)
    //             .ToListAsync();
    //     }

    //     public async Task<IEnumerable<CashWithdrawal>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
    //     {
    //         return await _context.CashWithdrawals
    //             .Where(w => w.DateTime >= fromDate && w.DateTime <= toDate)
    //             .OrderByDescending(w => w.DateTime)
    //             .ToListAsync();
    //     }

    //     public async Task<CashWithdrawal> CreateAsync(CashWithdrawal withdrawal)
    //     {
    //         withdrawal.Id = Guid.NewGuid();
    //         withdrawal.CreatedAt = DateTime.UtcNow;
    //         withdrawal.UpdatedAt = DateTime.UtcNow;
    //         withdrawal.Status = TransactionStatus.Completed;

    //         _context.CashWithdrawals.Add(withdrawal);
    //         await _context.SaveChangesAsync();
    //         return withdrawal;
    //     }

    //     public async Task<CashWithdrawal> UpdateAsync(CashWithdrawal withdrawal)
    //     {
    //         withdrawal.UpdatedAt = DateTime.UtcNow;
    //         _context.CashWithdrawals.Update(withdrawal);
    //         await _context.SaveChangesAsync();
    //         return withdrawal;
    //     }

    //     public async Task DeleteAsync(Guid id)
    //     {
    //         var withdrawal = await _context.CashWithdrawals.FindAsync(id);
    //         if (withdrawal != null)
    //         {
    //             _context.CashWithdrawals.Remove(withdrawal);
    //             await _context.SaveChangesAsync();
    //         }
    //     }
    // }
}