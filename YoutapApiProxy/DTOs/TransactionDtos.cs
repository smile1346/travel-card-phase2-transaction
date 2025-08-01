namespace TransactionService.DTOs
{
    public class CreateSpendingRequest
    {
        public Guid TripId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string MCC { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string? ReceiptUrl { get; set; }
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
    }

    public class CreateCashWithdrawalRequest
    {
        public Guid TripId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string ATMDeviceOwner { get; set; } = string.Empty;
        public string ATMDeviceId { get; set; } = string.Empty;
        public decimal Fee { get; set; }
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? TransactionReference { get; set; }
    }

    public class SpendingResponse
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string MCC { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string? ReceiptUrl { get; set; }
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CashWithdrawalResponse
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string ATMDeviceOwner { get; set; } = string.Empty;
        public string ATMDeviceId { get; set; } = string.Empty;
        public decimal Fee { get; set; }
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? TransactionReference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class TransactionSummaryResponse
    {
        public Guid TripId { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal TotalSpending { get; set; }
        public decimal TotalWithdrawals { get; set; }
        public decimal TotalFees { get; set; }
        public int SpendingCount { get; set; }
        public int WithdrawalCount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}