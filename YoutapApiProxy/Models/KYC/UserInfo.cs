using System.Text.Json.Serialization;

namespace UserInfoModel;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Account
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("externalId")]
    public string ExternalId { get; set; }

    [JsonPropertyName("accountType")]
    public string AccountType { get; set; }

    [JsonPropertyName("accountTypeDescription")]
    public string AccountTypeDescription { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("suspend")]
    public bool Suspend { get; set; }

    [JsonPropertyName("fraudlock")]
    public bool Fraudlock { get; set; }

    [JsonPropertyName("timezoneId")]
    public int TimezoneId { get; set; }

    [JsonPropertyName("javaTimezone")]
    public string JavaTimezone { get; set; }

    [JsonPropertyName("smsNotification")]
    public bool SmsNotification { get; set; }

    [JsonPropertyName("emailNotification")]
    public bool EmailNotification { get; set; }

    [JsonPropertyName("pushNotification")]
    public bool PushNotification { get; set; }

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
    public object ExpiryDate { get; set; }

    [JsonPropertyName("firstUsed")]
    public object FirstUsed { get; set; }

    [JsonPropertyName("firstUsedDate")]
    public object FirstUsedDate { get; set; }

    [JsonPropertyName("lastUsed")]
    public object LastUsed { get; set; }

    [JsonPropertyName("creationDate")]
    public long CreationDate { get; set; }

    [JsonPropertyName("balances")]
    public object Balances { get; set; }

    [JsonPropertyName("balanceTypes")]
    public object BalanceTypes { get; set; }

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
    public string Msisdn { get; set; }

    [JsonPropertyName("taxNumber")]
    public object TaxNumber { get; set; }

    [JsonPropertyName("taxRate")]
    public object TaxRate { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }
}

public class Address
{
    [JsonPropertyName("addressId")]
    public int AddressId { get; set; }

    [JsonPropertyName("addressType")]
    public string AddressType { get; set; }

    [JsonPropertyName("addLine1")]
    public object AddLine1 { get; set; }

    [JsonPropertyName("addLine2")]
    public object AddLine2 { get; set; }

    [JsonPropertyName("addLine3")]
    public object AddLine3 { get; set; }

    [JsonPropertyName("addLine4")]
    public object AddLine4 { get; set; }

    [JsonPropertyName("addLine5")]
    public object AddLine5 { get; set; }

    [JsonPropertyName("addLine6")]
    public object AddLine6 { get; set; }

    [JsonPropertyName("city")]
    public object City { get; set; }

    [JsonPropertyName("state")]
    public object State { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("postalCode")]
    public object PostalCode { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("phone1")]
    public object Phone1 { get; set; }

    [JsonPropertyName("customerId")]
    public string CustomerId { get; set; }

    [JsonPropertyName("addr3Id")]
    public object Addr3Id { get; set; }

    [JsonPropertyName("statId")]
    public object StatId { get; set; }

    [JsonPropertyName("cityId")]
    public object CityId { get; set; }

    [JsonPropertyName("countryId")]
    public object CountryId { get; set; }
}

public class Contact
{
    [JsonPropertyName("contactId")]
    public int ContactId { get; set; }

    [JsonPropertyName("contactType")]
    public string ContactType { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public object MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("title")]
    public object Title { get; set; }

    [JsonPropertyName("organisationName")]
    public object OrganisationName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("nationality")]
    public object Nationality { get; set; }

    [JsonPropertyName("dob")]
    public object Dob { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("email1")]
    public object Email1 { get; set; }

    [JsonPropertyName("email2")]
    public object Email2 { get; set; }

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
    public int CustId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Root
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("customerNumber")]
    public string CustomerNumber { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("entityName")]
    public string EntityName { get; set; }

    [JsonPropertyName("contactMethod")]
    public string ContactMethod { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("vendor")]
    public string Vendor { get; set; }

    [JsonPropertyName("parent")]
    public object Parent { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("profileId")]
    public object ProfileId { get; set; }

    [JsonPropertyName("contacts")]
    public List<Contact> Contacts { get; set; }

    [JsonPropertyName("accounts")]
    public List<Account> Accounts { get; set; }

    [JsonPropertyName("addresses")]
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
    public object CustomerNotes { get; set; }

    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [JsonPropertyName("creationDate")]
    public long CreationDate { get; set; }

    [JsonPropertyName("pin")]
    public object Pin { get; set; }

    [JsonPropertyName("tierRequirementVerifications")]
    public List<TierRequirementVerification> TierRequirementVerifications { get; set; }

    [JsonPropertyName("merchantCategoryCode")]
    public object MerchantCategoryCode { get; set; }

    [JsonPropertyName("securityAnswersCount")]
    public int SecurityAnswersCount { get; set; }

    [JsonPropertyName("requestedDeletion")]
    public bool RequestedDeletion { get; set; }

    [JsonPropertyName("locked")]
    public bool Locked { get; set; }
}

public class TierRequirementVerification
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("verified")]
    public object Verified { get; set; }

    [JsonPropertyName("note")]
    public object Note { get; set; }
}

