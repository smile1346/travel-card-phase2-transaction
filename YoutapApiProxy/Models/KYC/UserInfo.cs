using System.Text.Json.Serialization;

namespace UserInfoModel;

public class Account
{
    [JsonPropertyName("accountCreator")]
    public string AccountCreator { get; set; }

    [JsonPropertyName("accountGroup")]
    public string AccountGroup { get; set; }

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("accountPin")]
    public object AccountPin { get; set; }

    [JsonPropertyName("accountType")]
    public string AccountType { get; set; }

    [JsonPropertyName("accountTypeDescription")]
    public string AccountTypeDescription { get; set; }

    [JsonPropertyName("balanceTypes")]
    public object BalanceTypes { get; set; }

    [JsonPropertyName("balances")]
    public object Balances { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("creationDate")]
    public long CreationDate { get; set; }

    [JsonPropertyName("customerName")]
    public object CustomerName { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("emailNotification")]
    public bool EmailNotification { get; set; }

    [JsonPropertyName("expiryDate")]
    public object ExpiryDate { get; set; }

    [JsonPropertyName("firstUsed")]
    public object FirstUsed { get; set; }

    [JsonPropertyName("firstUsedDate")]
    public object FirstUsedDate { get; set; }

    [JsonPropertyName("fraudlock")]
    public bool Fraudlock { get; set; }

    [JsonPropertyName("glcode")]
    public object Glcode { get; set; }

    [JsonPropertyName("javaTimezone")]
    public string JavaTimezone { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("lastUsed")]
    public object LastUsed { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("parentAccountCust")]
    public object ParentAccountCust { get; set; }

    [JsonPropertyName("parentAccountId")]
    public object ParentAccountId { get; set; }

    [JsonPropertyName("pushNotification")]
    public bool PushNotification { get; set; }

    [JsonPropertyName("smsNotification")]
    public bool SmsNotification { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("suspend")]
    public bool Suspend { get; set; }

    [JsonPropertyName("taxNumber")]
    public object TaxNumber { get; set; }

    [JsonPropertyName("taxRate")]
    public object TaxRate { get; set; }

    [JsonPropertyName("timezoneId")]
    public int TimezoneId { get; set; }

    [JsonPropertyName("upgradeOption")]
    public object UpgradeOption { get; set; }

    [JsonPropertyName("vendor")]
    public object Vendor { get; set; }

    [JsonPropertyName("walletType")]
    public object WalletType { get; set; }
}

public class Address
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("addLine2")]
    public string AddLine2 { get; set; }

    [JsonPropertyName("addLine3")]
    public object AddLine3 { get; set; }

    [JsonPropertyName("addLine4")]
    public string AddLine4 { get; set; }

    [JsonPropertyName("addLine5")]
    public object AddLine5 { get; set; }

    [JsonPropertyName("addLine6")]
    public object AddLine6 { get; set; }

    [JsonPropertyName("addr3Id")]
    public object Addr3Id { get; set; }

    [JsonPropertyName("addressId")]
    public int AddressId { get; set; }

    [JsonPropertyName("addressType")]
    public string AddressType { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("cityId")]
    public int CityId { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("countryId")]
    public object CountryId { get; set; }

    [JsonPropertyName("customerId")]
    public string CustomerId { get; set; }

    [JsonPropertyName("latitude")]
    public int Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public int Longitude { get; set; }

    [JsonPropertyName("phone1")]
    public string Phone1 { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("statId")]
    public int StatId { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }
}

public class Contact
{
    [JsonPropertyName("contactId")]
    public int ContactId { get; set; }

    [JsonPropertyName("contactType")]
    public string ContactType { get; set; }

    [JsonPropertyName("contidcountry")]
    public object Contidcountry { get; set; }

    [JsonPropertyName("contidexpiry")]
    public object Contidexpiry { get; set; }

    [JsonPropertyName("contidissuer")]
    public object Contidissuer { get; set; }

    [JsonPropertyName("contidnumber")]
    public object Contidnumber { get; set; }

    [JsonPropertyName("custId")]
    public int CustId { get; set; }

    [JsonPropertyName("dob")]
    public object Dob { get; set; }

    [JsonPropertyName("email1")]
    public string Email1 { get; set; }

    [JsonPropertyName("email2")]
    public object Email2 { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("idntid")]
    public object Idntid { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("middleName")]
    public object MiddleName { get; set; }

    [JsonPropertyName("nationality")]
    public string Nationality { get; set; }

    [JsonPropertyName("organisationName")]
    public object OrganisationName { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("title")]
    public object Title { get; set; }
}

public class Identifier
{
    [JsonPropertyName("expiryDate")]
    public object ExpiryDate { get; set; }

    [JsonPropertyName("identifierCode")]
    public string IdentifierCode { get; set; }

    [JsonPropertyName("identifierDesc")]
    public string IdentifierDesc { get; set; }

    [JsonPropertyName("identifierId")]
    public int IdentifierId { get; set; }

    [JsonPropertyName("identifierType")]
    public string IdentifierType { get; set; }

    [JsonPropertyName("photoIdentities")]
    public List<PhotoIdentity> PhotoIdentities { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("verified")]
    public object Verified { get; set; }
}

public class PhotoIdentity
{
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("imageId")]
    public string ImageId { get; set; }
}

public class Root
{
    [JsonPropertyName("accounts")]
    public List<Account> Accounts { get; set; }

    [JsonPropertyName("addresses")]
    public List<Address> Addresses { get; set; }

    [JsonPropertyName("businessCategory")]
    public object BusinessCategory { get; set; }

    [JsonPropertyName("businessCategoryId")]
    public object BusinessCategoryId { get; set; }

    [JsonPropertyName("businessName")]
    public object BusinessName { get; set; }

    [JsonPropertyName("businessOwner")]
    public object BusinessOwner { get; set; }

    [JsonPropertyName("contactMethod")]
    public string ContactMethod { get; set; }

    [JsonPropertyName("contacts")]
    public List<Contact> Contacts { get; set; }

    [JsonPropertyName("creationDate")]
    public long CreationDate { get; set; }

    [JsonPropertyName("customerNotes")]
    public string CustomerNotes { get; set; }

    [JsonPropertyName("customerNumber")]
    public string CustomerNumber { get; set; }

    [JsonPropertyName("entityName")]
    public string EntityName { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("identifiers")]
    public List<Identifier> Identifiers { get; set; }

    [JsonPropertyName("merchantCategoryCode")]
    public object MerchantCategoryCode { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("natureOfWork")]
    public object NatureOfWork { get; set; }

    [JsonPropertyName("occupation")]
    public object Occupation { get; set; }

    [JsonPropertyName("parent")]
    public object Parent { get; set; }

    [JsonPropertyName("pin")]
    public object Pin { get; set; }

    [JsonPropertyName("profileId")]
    public object ProfileId { get; set; }

    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [JsonPropertyName("securityAnswersCount")]
    public int SecurityAnswersCount { get; set; }

    [JsonPropertyName("sourceOfIncome")]
    public object SourceOfIncome { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("tierRequirementVerifications")]
    public List<TierRequirementVerification> TierRequirementVerifications { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("vendor")]
    public string Vendor { get; set; }
}

public class TierRequirementVerification
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("note")]
    public object Note { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("verified")]
    public bool Verified { get; set; }
}

