namespace Models;

public class CustomerUpdateRequestPayload
{
    public string walletProviderId;
    public string mobileNumber;
    public CustomerContact customerContacts;
    public CustomerAddress customerAddress;
}

public class CustomerContact
{
    public int ContactId { get; set; }
    public string ContactTypeDescription { get; set; }
    public string ContSalutation { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string Gender { get; set; }
    public string Email1 { get; set; }
    public string Email2 { get; set; }
    public DateTime Dob { get; set; }
    public string Nationality { get; set; }
    public bool Primary { get; set; }
    public string Status { get; set; }
}

public class CustomerAddress
{
    public int AddressId { get; set; }
    public string AddressType { get; set; }
    public string AddrLine1 { get; set; }
    public string AddrLine2 { get; set; }
    public string AddrLine3 { get; set; }
    public string AddrLine4 { get; set; }
    public string AddrLine5 { get; set; }
    public string AddrLine6 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Postcode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Addr3Id { get; set; }
    public int StatId { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public string Status { get; set; }
}