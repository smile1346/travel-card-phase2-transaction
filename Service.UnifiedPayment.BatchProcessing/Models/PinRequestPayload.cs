namespace Models;

struct PinCreateRequestPayload
{
    public string pin;
}

struct PinUpdateRequestPayload
{
    public string oldPin;
    public string newPin;
}