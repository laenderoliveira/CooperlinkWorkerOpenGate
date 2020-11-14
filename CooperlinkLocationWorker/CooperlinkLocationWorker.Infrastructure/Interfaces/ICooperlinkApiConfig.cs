namespace CooperlinkLocationWorker.Infrastructure.Interfaces
{
    public interface ICooperlinkApiConfig
    {
        public string UrlBase { get; }
        public string Username { get; }
        public string Password { get; }
        public string RouteToken { get; }
        public string RouteVehicle { get; }
    }
}
