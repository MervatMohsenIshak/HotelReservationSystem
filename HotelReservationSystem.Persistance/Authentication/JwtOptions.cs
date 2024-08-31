namespace HotelReservationSystem.Persistence.Authentication
{
    public class JwtOptions
    {
        public string JwtIssuer { get; init; }
        public string JwtAudience { get; init; }
        public string JwtKey { get; init; }
        public int TokenExpirationMinutes { get; init; }
    }
}
