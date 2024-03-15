namespace Models;

public class CustomerCreateRequestPayload
{
    public string walletProviderId;
    public string mobileNumber;
    public string businessCategoryId;
    public string contactTypeId;
    public string customerCategoryId;
    public string referralCode;
    public KYCInfo kycInfo;
}

public class Address
{
    public string AddressType { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }
    public string Address5 { get; set; }
    public string Address6 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int StateID { get; set; }
    public int CityID { get; set; }
    public int CountryID { get; set; }
    public int Addr3ID { get; set; }
    public string PostalCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Contact
{
    public string CustomerName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Email1 { get; set; }
    public string Email2 { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
}

public class Identifier
{
    public int customerIdentifierId { get; set; }
    public string customerIdentifierValue { get; set; }
    public DateTime customerIdentifierExpiryDate { get; set; }
    public byte[] customerIdentifierImage { get; set; }
    public string customerIdentifierImageMimeType { get; set; }
}