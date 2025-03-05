namespace SPSS.Dto
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
