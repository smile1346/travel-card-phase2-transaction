namespace TransactionService.Models
{
    public class Spending
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string MCC { get; set; } = string.Empty; // Merchant Category Code
        public string MerchantName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Additional fields for tracking
        public string? ReceiptUrl { get; set; }
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
    }

    public class CashWithdrawal
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
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Additional tracking fields
        public decimal? LocalAmount { get; set; }
        public string? LocalCurrency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? TransactionReference { get; set; }
    }

    public enum TransactionStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3,
        Cancelled = 4,
        Refunded = 5
    }

    public enum PaymentMethod
    {
        Card = 1,
        Cash = 2,
        BankTransfer = 3,
        DigitalWallet = 4,
        Other = 5
    }
}