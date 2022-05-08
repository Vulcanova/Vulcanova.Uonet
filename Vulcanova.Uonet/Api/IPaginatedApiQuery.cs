namespace Vulcanova.Uonet.Api
{
    public interface IPaginatedApiQuery<T> : IApiQuery<T[]> where T : IPaginatedResource
    {
        int LastId { get; }
        int PageSize { get; }

        IPaginatedApiQuery<T> NextPage(int lastId);
    }
}