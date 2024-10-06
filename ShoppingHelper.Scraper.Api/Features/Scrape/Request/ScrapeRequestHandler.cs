using MassTransit;
using MediatR;
using ShoppingHelper.Scraper.Contracts.Commands;

namespace ShoppingHelper.Scraper.Api.Features.Scrape.Request;

public class ScrapeRequestHandler(IBus IBus) : IRequestHandler<ScrapeRequestCommand, ScrapeRequestResponse>
{
    private readonly IBus _iBus = IBus;

    public async Task<ScrapeRequestResponse> Handle(ScrapeRequestCommand request, CancellationToken cancellationToken)
    {
        var scrapeRequestId = Guid.NewGuid();
        var sendEndpoint = await _iBus.GetPublishSendEndpoint<ScrapeRequestedCommand>();
        await sendEndpoint.Send(new ScrapeRequestedCommand(request.RecipeSource), o => o.MessageId = scrapeRequestId, cancellationToken);

        var response = new ScrapeRequestResponse(scrapeRequestId);

        return response;
    }
}
