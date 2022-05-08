using System.Linq;
using System.Threading.Tasks;
using Moq;
using Vulcanova.Uonet.Api;
using Xunit;

namespace Vulcanova.Uonet.UnitTests.Api;

public class ApiClientExtensionsTests
{
    [Fact]
    public async Task GetAllPagesAsync_PaginatedQuery_KeepsQueryingUntilEmptyResult()
    {
        var items = Enumerable.Range(0, 17)
            .Select(i => new SampleResource(i))
            .ToArray();

        var apiMock = new Mock<IApiClient>();

        apiMock.Setup(x => x.GetAsync(SampleQuery.ApiEndpoint, It.IsAny<IPaginatedApiQuery<SampleResource>>()))
            .ReturnsAsync((string _, IPaginatedApiQuery<SampleResource> query) =>
            {
                var result = items.SkipWhile(i => i.Id <= query.LastId)
                    .Take(query.PageSize)
                    .ToArray();

                return new ApiResponse<SampleResource[]>
                {
                    Envelope = result
                };
            });

        var query = new SampleQuery(5, -1);

        var result = await apiMock.Object.GetAllPagesAsync(SampleQuery.ApiEndpoint, query)
            .ToListAsync();

        Assert.Collection(result,
            page => Assert.True(page.SequenceEqual(items[..5])),
            page => Assert.True(page.SequenceEqual(items[5..10])),
            page => Assert.True(page.SequenceEqual(items[10..15])),
            page => Assert.True(page.SequenceEqual(items[15..])));
    }
}

public record SampleResource(int Id) : IPaginatedResource;

public record SampleQuery(int PageSize, int LastId) : IPaginatedApiQuery<SampleResource>
{
    public IPaginatedApiQuery<SampleResource> NextPage(int lastId)
        => this with {LastId = lastId};

    public const string ApiEndpoint = "https://resource";
}