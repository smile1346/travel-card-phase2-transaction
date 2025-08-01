using TransactionService.DTOs;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Services
{
    public class SpendingService : ISpendingService
    {
        private readonly ISpendingRepository _spendingRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public SpendingService(ISpendingRepository spendingRepository, IHttpClientFactory httpClientFactory)
        {
            _spendingRepository = spendingRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SpendingResponse> CreateSpendingAsync(CreateSpendingRequest request)
        {
            // Validate trip exists
            var tripClient = _httpClientFactory.CreateClient("TripService");
            var tripResponse = await tripClient.GetAsync($"/api/trips/{request.TripId}");
            
            if (!tripResponse.IsSuccessStatusCode)
            {
                throw new ArgumentException("Trip not found");
            }

            var spending = new Spending
            {
                TripId = request.TripId,
                CustomerId = request.CustomerId,
                Amount = request.Amount,
                Currency = request.Currency,
                DateTime = request.DateTime,
                Location = request.Location,
                MCC = request.MCC,
                MerchantName = request.MerchantName,
                Description = request.Description,
                PaymentMethod = request.PaymentMethod,
                ReceiptUrl = request.ReceiptUrl,
                LocalAmount = request.LocalAmount,
                LocalCurrency = request.LocalCurrency,
                ExchangeRate = request.ExchangeRate
            };

            var createdSpending = await _spendingRepository.CreateAsync(spending);

            // Trigger location update
            await UpdateLocationVisitAsync(request.TripId, request.Location);

            // Create automatic split if configured
            await CreateAutomaticSplitAsync(createdSpending);

            return MapToSpendingResponse(createdSpending);
        }

        public async Task<SpendingResponse?> GetSpendingByIdAsync(Guid id)
        {
            var spending = await _spendingRepository.GetByIdAsync(id);
            return spending != null ? MapToSpendingResponse(spending) : null;
        }

        public async Task<IEnumerable<SpendingResponse>> GetSpendingsByTripIdAsync(Guid tripId)
        {
            var spendings = await _spendingRepository.GetByTripIdAsync(tripId);
            return spendings.Select(MapToSpendingResponse);
        }

        public async Task<IEnumerable<SpendingResponse>> GetSpendingsByCustomerIdAsync(string customerId)
        {
            var spendings = await _spendingRepository.GetByCustomerIdAsync(customerId);
            return spendings.Select(MapToSpendingResponse);
        }

        public async Task<SpendingResponse> UpdateSpendingAsync(Guid id, CreateSpendingRequest request)
        {
            var spending = await _spendingRepository.GetByIdAsync(id);
            if (spending == null)
                throw new ArgumentException("Spending not found");

            spending.Amount = request.Amount;
            spending.Currency = request.Currency;
            spending.DateTime = request.DateTime;
            spending.Location = request.Location;
            spending.MCC = request.MCC;
            spending.MerchantName = request.MerchantName;
            spending.Description = request.Description;
            spending.PaymentMethod = request.PaymentMethod;
            spending.ReceiptUrl = request.ReceiptUrl;
            spending.LocalAmount = request.LocalAmount;
            spending.LocalCurrency = request.LocalCurrency;
            spending.ExchangeRate = request.ExchangeRate;

            var updatedSpending = await _spendingRepository.UpdateAsync(spending);
            return MapToSpendingResponse(updatedSpending);
        }

        // public async Task<SpendingResponse> UpdateSpendingStatusAsync(Guid id, TransactionStatus status)
        // {
        //     var spending = await _spendingRepository.GetByIdAsync(id);
        //     if (spending == null)
        //         throw new ArgumentException("Spending not found");

        //     spending.Status = status;
        //     var updatedSpending = await _spendingRepository.UpdateAsync(spending);
        //     return MapToSpendingResponse(updatedSpending);
        // }

        public async Task DeleteSpendingAsync(Guid id)
        {
            await _spendingRepository.DeleteAsync(id);
        }

        public async Task<TransactionSummaryResponse> GetTripSummaryAsync(Guid tripId)
        {
            var spendings = await _spendingRepository.GetByTripIdAsync(tripId);
            
            var summary = new TransactionSummaryResponse
            {
                TripId = tripId,
                Currency = spendings.FirstOrDefault()?.Currency ?? "USD",
                TotalSpending = spendings.Sum(s => s.Amount),
                SpendingCount = spendings.Count(),
                FromDate = spendings.Any() ? spendings.Min(s => s.DateTime) : DateTime.UtcNow,
                ToDate = spendings.Any() ? spendings.Max(s => s.DateTime) : DateTime.UtcNow
            };

            return summary;
        }

        private async Task UpdateLocationVisitAsync(Guid tripId, string location)
        {
            try
            {
                var locationClient = _httpClientFactory.CreateClient("LocationService");
                var locationData = new
                {
                    TripId = tripId,
                    Location = location,
                    VisitDateTime = DateTime.UtcNow
                };

                await locationClient.PostAsJsonAsync("/api/locations/visits", locationData);
            }
            catch
            {
                // Log error but don't fail the transaction
            }
        }

        private async Task CreateAutomaticSplitAsync(Spending spending)
        {
            try
            {
                var splitClient = _httpClientFactory.CreateClient("SplitService");
                var splitData = new
                {
                    TransactionId = spending.Id,
                    TripId = spending.TripId,
                    TotalAmount = spending.Amount,
                    SplitType = 1, // Equal split by default
                    Currency = spending.Currency,
                    PayerId = spending.CustomerId,
                    PayerName = "Auto", // Would need to get from customer service
                    Participants = new[] { new { MemberId = spending.CustomerId, MemberName = "Auto" } }
                };

                await splitClient.PostAsJsonAsync("/api/splits", splitData);
            }
            catch
            {
                // Log error but don't fail the transaction
            }
        }

        private static SpendingResponse MapToSpendingResponse(Spending spending)
        {
            return new SpendingResponse
            {
                Id = spending.Id,
                TripId = spending.TripId,
                CustomerId = spending.CustomerId,
                Amount = spending.Amount,
                Currency = spending.Currency,
                DateTime = spending.DateTime,
                Location = spending.Location,
                MCC = spending.MCC,
                MerchantName = spending.MerchantName,
                Description = spending.Description,
                PaymentMethod = spending.PaymentMethod,
                ReceiptUrl = spending.ReceiptUrl,
                LocalAmount = spending.LocalAmount,
                LocalCurrency = spending.LocalCurrency,
                ExchangeRate = spending.ExchangeRate,
                CreatedAt = spending.CreatedAt,
                UpdatedAt = spending.UpdatedAt
            };
        }
    }

    // public class CashWithdrawalService : ICashWithdrawalService
    // {
    //     private readonly ICashWithdrawalRepository _withdrawalRepository;
    //     private readonly IHttpClientFactory _httpClientFactory;

    //     public CashWithdrawalService(ICashWithdrawalRepository withdrawalRepository, IHttpClientFactory httpClientFactory)
    //     {
    //         _withdrawalRepository = withdrawalRepository;
    //         _httpClientFactory = httpClientFactory;
    //     }

    //     public async Task<CashWithdrawalResponse> CreateWithdrawalAsync(CreateCashWithdrawalRequest request)
    //     {
    //         // Validate trip exists
    //         var tripClient = _httpClientFactory.CreateClient("TripService");
    //         var tripResponse = await tripClient.GetAsync($"/api/trips/{request.TripId}");
            
    //         if (!tripResponse.IsSuccessStatusCode)
    //         {
    //             throw new ArgumentException("Trip not found");
    //         }

    //         var withdrawal = new CashWithdrawal
    //         {
    //             TripId = request.TripId,
    //             CustomerId = request.CustomerId,
    //             Amount = request.Amount,
    //             Currency = request.Currency,
    //             DateTime = request.DateTime,
    //             Location = request.Location,
    //             ATMDeviceOwner = request.ATMDeviceOwner,
    //             ATMDeviceId = request.ATMDeviceId,
    //             Fee = request.Fee,
    //             LocalAmount = request.LocalAmount,
    //             LocalCurrency = request.LocalCurrency,
    //             ExchangeRate = request.ExchangeRate,
    //             TransactionReference = request.TransactionReference
    //         };

    //         var createdWithdrawal = await _withdrawalRepository.CreateAsync(withdrawal);

    //         // Update location visit
    //         await UpdateLocationVisitAsync(request.TripId, request.Location);

    //         return MapToCashWithdrawalResponse(createdWithdrawal);
    //     }

    //     public async Task<CashWithdrawalResponse?> GetWithdrawalByIdAsync(Guid id)
    //     {
    //         var withdrawal = await _withdrawalRepository.GetByIdAsync(id);
    //         return withdrawal != null ? MapToCashWithdrawalResponse(withdrawal) : null;
    //     }

    //     public async Task<IEnumerable<CashWithdrawalResponse>> GetWithdrawalsByTripIdAsync(Guid tripId)
    //     {
    //         var withdrawals = await _withdrawalRepository.GetByTripIdAsync(tripId);
    //         return withdrawals.Select(MapToCashWithdrawalResponse);
    //     }

    //     public async Task<IEnumerable<CashWithdrawalResponse>> GetWithdrawalsByCustomerIdAsync(string customerId)
    //     {
    //         var withdrawals = await _withdrawalRepository.GetByCustomerIdAsync(customerId);
    //         return withdrawals.Select(MapToCashWithdrawalResponse);
    //     }

    //     public async Task<CashWithdrawalResponse> UpdateWithdrawalAsync(Guid id, CreateCashWithdrawalRequest request)
    //     {
    //         var withdrawal = await _withdrawalRepository.GetByIdAsync(id);
    //         if (withdrawal == null)
    //             throw new ArgumentException("Withdrawal not found");

    //         withdrawal.Amount = request.Amount;
    //         withdrawal.Currency = request.Currency;
    //         withdrawal.DateTime = request.DateTime;
    //         withdrawal.Location = request.Location;
    //         withdrawal.ATMDeviceOwner = request.ATMDeviceOwner;
    //         withdrawal.ATMDeviceId = request.ATMDeviceId;
    //         withdrawal.Fee = request.Fee;
    //         withdrawal.LocalAmount = request.LocalAmount;
    //         withdrawal.LocalCurrency = request.LocalCurrency;
    //         withdrawal.ExchangeRate = request.ExchangeRate;
    //         withdrawal.TransactionReference = request.TransactionReference;

    //         var updatedWithdrawal = await _withdrawalRepository.UpdateAsync(withdrawal);
    //         return MapToCashWithdrawalResponse(updatedWithdrawal);
    //     }

    //     public async Task<CashWithdrawalResponse> UpdateWithdrawalStatusAsync(Guid id, TransactionStatus status)
    //     {
    //         var withdrawal = await _withdrawalRepository.GetByIdAsync(id);
    //         if (withdrawal == null)
    //             throw new ArgumentException("Withdrawal not found");

    //         withdrawal.Status = status;
    //         var updatedWithdrawal = await _withdrawalRepository.UpdateAsync(withdrawal);
    //         return MapToCashWithdrawalResponse(updatedWithdrawal);
    //     }

    //     public async Task DeleteWithdrawalAsync(Guid id)
    //     {
    //         await _withdrawalRepository.DeleteAsync(id);
    //     }

    //     private async Task UpdateLocationVisitAsync(Guid tripId, string location)
    //     {
    //         try
    //         {
    //             var locationClient = _httpClientFactory.CreateClient("LocationService");
    //             var locationData = new
    //             {
    //                 TripId = tripId,
    //                 Location = location,
    //                 VisitDateTime = DateTime.UtcNow
    //             };

    //             await locationClient.PostAsJsonAsync("/api/locations/visits", locationData);
    //         }
    //         catch
    //         {
    //             // Log error but don't fail the transaction
    //         }
    //     }

    //     private static CashWithdrawalResponse MapToCashWithdrawalResponse(CashWithdrawal withdrawal)
    //     {
    //         return new CashWithdrawalResponse
    //         {
    //             Id = withdrawal.Id,
    //             TripId = withdrawal.TripId,
    //             CustomerId = withdrawal.CustomerId,
    //             Amount = withdrawal.Amount,
    //             Currency = withdrawal.Currency,
    //             DateTime = withdrawal.DateTime,
    //             Location = withdrawal.Location,
    //             ATMDeviceOwner = withdrawal.ATMDeviceOwner,
    //             ATMDeviceId = withdrawal.ATMDeviceId,
    //             Fee = withdrawal.Fee,
    //             Status = withdrawal.Status,
    //             LocalAmount = withdrawal.LocalAmount,
    //             LocalCurrency = withdrawal.LocalCurrency,
    //             ExchangeRate = withdrawal.ExchangeRate,
    //             TransactionReference = withdrawal.TransactionReference,
    //             CreatedAt = withdrawal.CreatedAt,
    //             UpdatedAt = withdrawal.UpdatedAt
    //         };
    //     }
    // }
}