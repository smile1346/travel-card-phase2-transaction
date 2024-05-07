using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace KYCRegistrationResponseModel;

public class Account
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("accountId")]
    //[Required]
    [SwaggerSchema("AccountID is used for several API's. Rabbit should save this value.")]
    public int AccountId { get; set; }

    [JsonPropertyName("externalId")]
    //[Required]
    [SwaggerSchema("Example: 16001 0811001000\n\n160 = Provider (Rabbit)\n\n01 = Wallet type (Consumer Wallet)\n\n0811001000 = account id 10 digits")]
    public string ExternalId { get; set; }

    [JsonPropertyName("accountType")]
    //[Required]
    [SwaggerSchema("The type of the account")]
    public string AccountType { get; set; }

    [JsonPropertyName("accountTypeDescription")]
    public object AccountTypeDescription { get; set; }

    [JsonPropertyName("status")]
    //[Required]
    public string Status { get; set; }

    [JsonPropertyName("suspend")]
    public bool Suspend { get; set; }

    [JsonPropertyName("fraudlock")]
    public bool Fraudlock { get; set; }

    [JsonPropertyName("timezoneId")]
    public object TimezoneId { get; set; }

    [JsonPropertyName("javaTimezone")]
    public object JavaTimezone { get; set; }

    [JsonPropertyName("smsNotification")]
    public object SmsNotification { get; set; }

    [JsonPropertyName("emailNotification")]
    public object EmailNotification { get; set; }

    [JsonPropertyName("pushNotification")]
    public object PushNotification { get; set; }

    [JsonPropertyName("walletType")]
    public object WalletType { get; set; }

    [JsonPropertyName("name")]
    public object Name { get; set; }

    [JsonPropertyName("color")]
    public object Color { get; set; }

    [JsonPropertyName("accountGroup")]
    public string AccountGroup { get; set; }

    [JsonPropertyName("accountCreator")]
    public string AccountCreator { get; set; }

    [JsonPropertyName("accountPin")]
    public object AccountPin { get; set; }

    [JsonPropertyName("expiryDate")]
    public DateTime ExpiryDate { get; set; }

    [JsonPropertyName("firstUsed")]
    public object FirstUsed { get; set; }

    [JsonPropertyName("firstUsedDate")]
    public object FirstUsedDate { get; set; }

    [JsonPropertyName("lastUsed")]
    public object LastUsed { get; set; }

    [JsonPropertyName("creationDate")]
    public object CreationDate { get; set; }

    [JsonPropertyName("balances")]
    public object Balances { get; set; }

    [JsonPropertyName("balanceTypes")]
    public List<object> BalanceTypes { get; set; }

    [JsonPropertyName("customerName")]
    public object CustomerName { get; set; }

    [JsonPropertyName("parentAccountId")]
    public object ParentAccountId { get; set; }

    [JsonPropertyName("parentAccountCust")]
    public object ParentAccountCust { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("glcode")]
    public object Glcode { get; set; }

    [JsonPropertyName("upgradeOption")]
    public object UpgradeOption { get; set; }

    [JsonPropertyName("vendor")]
    public object Vendor { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("taxNumber")]
    public object TaxNumber { get; set; }

    [JsonPropertyName("taxRate")]
    public object TaxRate { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("default")]
    public object Default { get; set; }
}

public class Address
{
    [JsonPropertyName("addressId")]
    [SwaggerSchema("The unique identifier for the address.")]
    public int AddressId { get; set; }

    [JsonPropertyName("addressType")]
    [SwaggerSchema("Type of address")]
    public string AddressType { get; set; }

    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("addLine2")]
    public string AddLine2 { get; set; }

    [JsonPropertyName("addLine3")]
    public string AddLine3 { get; set; }

    [JsonPropertyName("addLine4")]
    public string AddLine4 { get; set; }

    [JsonPropertyName("addLine5")]
    public object AddLine5 { get; set; }

    [JsonPropertyName("addLine6")]
    public object AddLine6 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("country")]
    [SwaggerSchema("Country name. Return from request")]
    public string Country { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("fax1")]
    public object Fax1 { get; set; }

    [JsonPropertyName("fax2")]
    public object Fax2 { get; set; }

    [JsonPropertyName("phone1")]
    public object Phone1 { get; set; }

    [JsonPropertyName("phone2")]
    public object Phone2 { get; set; }

    [JsonPropertyName("customerId")]
    public object CustomerId { get; set; }

    [JsonPropertyName("addr3Id")]
    public object Addr3Id { get; set; }

    [JsonPropertyName("statId")]
    public object StatId { get; set; }

    [JsonPropertyName("cityId")]
    public object CityId { get; set; }

    [JsonPropertyName("countryId")]
    public object CountryId { get; set; }

    [JsonPropertyName("status")]
    public object Status { get; set; }
}

public class Contact
{
    [JsonPropertyName("contactId")]
    //[Required]
    public int ContactId { get; set; }

    [JsonPropertyName("contactType")]
    //[Required]
    [SwaggerSchema("Type of contact.")]
    public string ContactType { get; set; }

    [JsonPropertyName("firstName")]
    //[Required]
    [SwaggerSchema("First name of the user")]
    public string FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    [SwaggerSchema("Last name of the user")]
    public string LastName { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("organisationName")]
    public string OrganisationName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("nationality")]
    public string Nationality { get; set; }

    [JsonPropertyName("dob")]
    public string Dob { get; set; }

    [JsonPropertyName("primary")]
    //[Required]
    public bool Primary { get; set; }

    [JsonPropertyName("email1")]
    public string Email1 { get; set; }

    [JsonPropertyName("email2")]
    public string Email2 { get; set; }

    [JsonPropertyName("idntid")]
    public object Idntid { get; set; }

    [JsonPropertyName("contidnumber")]
    public object Contidnumber { get; set; }

    [JsonPropertyName("contidexpiry")]
    public object Contidexpiry { get; set; }

    [JsonPropertyName("contidcountry")]
    public object Contidcountry { get; set; }

    [JsonPropertyName("contidissuer")]
    public object Contidissuer { get; set; }

    [JsonPropertyName("custId")]
    public object CustId { get; set; }

    [JsonPropertyName("status")]
    public object Status { get; set; }
}

public class Root
{
    [JsonPropertyName("id")]
    //[Required]
    public int Id { get; set; }

    [JsonPropertyName("customerNumber")]
    //[Required]
    [SwaggerSchema("Unique identifier for the customer. The wallet provider stores this ID to facilitate inquiries into account lists, transaction history, and other services related to the customer")]
    public string CustomerNumber { get; set; }

    [JsonPropertyName("status")]
    //[Required]
    [SwaggerSchema("Status values in API documentation.")]
    public string Status { get; set; }

    [JsonPropertyName("entityName")]
    //[Required]
    [SwaggerSchema("Customer/entity name. Return from the request")]
    public string EntityName { get; set; }

    [JsonPropertyName("contactMethod")]
    //[Required]
    [SwaggerSchema("Defaults to phone/msisdn.")]
    public string ContactMethod { get; set; }

    [JsonPropertyName("type")]
    //[Required]
    [SwaggerSchema("Type of customer. Uses default.")]
    public string Type { get; set; }

    [JsonPropertyName("vendor")]
    public object Vendor { get; set; }

    [JsonPropertyName("parent")]
    public object Parent { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("profileId")]
    public object ProfileId { get; set; }

    [JsonPropertyName("contacts")]
    //[Required]
    [SwaggerSchema("Only 1 record from register. Can set more later. The DTO is reusable.")]
    public List<Contact> Contacts { get; set; }

    [JsonPropertyName("accounts")]
    //[Required]
    public List<Account> Accounts { get; set; }

    [JsonPropertyName("addresses")]
    [SwaggerSchema("A list of additional addresses that may be used by the customer such as billing or delivery.")]
    public List<Address> Addresses { get; set; }

    [JsonPropertyName("identifiers")]
    public List<object> Identifiers { get; set; }

    [JsonPropertyName("sourceOfIncome")]
    public object SourceOfIncome { get; set; }

    [JsonPropertyName("businessName")]
    public object BusinessName { get; set; }

    [JsonPropertyName("businessOwner")]
    public object BusinessOwner { get; set; }

    [JsonPropertyName("businessCategory")]
    public object BusinessCategory { get; set; }

    [JsonPropertyName("businessCategoryId")]
    public object BusinessCategoryId { get; set; }

    [JsonPropertyName("natureOfWork")]
    public object NatureOfWork { get; set; }

    [JsonPropertyName("occupation")]
    public object Occupation { get; set; }

    [JsonPropertyName("customerNotes")]
    public string CustomerNotes { get; set; }

    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [JsonPropertyName("linkedExternalAccounts")]
    public List<object> LinkedExternalAccounts { get; set; }

    [JsonPropertyName("taxTypeValues")]
    public object TaxTypeValues { get; set; }

    [JsonPropertyName("creationDate")]
    //[Required]
    [SwaggerSchema("Epoch timestamp in milliseconds")]
    public long CreationDate { get; set; }

    [JsonPropertyName("pin")]
    public object Pin { get; set; }

    [JsonPropertyName("tierRequirementVerifications")]
    public List<object> TierRequirementVerifications { get; set; }

    [JsonPropertyName("merchantCategoryCode")]
    public object MerchantCategoryCode { get; set; }

    [JsonPropertyName("requestedDeletion")]
    public bool RequestedDeletion { get; set; }

    [JsonPropertyName("locked")]
    public bool Locked { get; set; }
}

