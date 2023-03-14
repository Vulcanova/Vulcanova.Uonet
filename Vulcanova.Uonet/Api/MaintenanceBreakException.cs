namespace Vulcanova.Uonet.Api
{
    public class MaintenanceBreakException : UnexpectedApiResponseException
    {
        public MaintenanceBreakException(string content) : base(content)
        {
        }
    }
}