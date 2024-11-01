namespace RenphoGarminSync.Garmin.Auth.Models
{
    public class ServiceTicketResult
    {
        public string ServiceTicket { get; set; }
        public string ServiceUrl { get; set; }
        public GarminMFAState MFAState { get; set; }
    }
}
