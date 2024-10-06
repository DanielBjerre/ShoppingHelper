namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshAccessTokenService;

public class HardCodedHelloFreshAccessTokenService : IHelloFreshAccessTokenService
{
    public Task<string> GetAccessToken(CancellationToken cancellationToken)
    {
        var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MzA3MDM5NjksImlhdCI6MTcyODA3NDIyNiwiaXNzIjoic2VuZiIsImp0aSI6IjIzNzgwZDU5LTkwMTgtNGYwZS04ODRiLTMzNWFiMDM5MzQxYyJ9.aMG0GzmpGPFZYsEiigS0iRdoaM36yW5wiDiZcDHo3TA";

        return Task.FromResult(accessToken);
    }
}
