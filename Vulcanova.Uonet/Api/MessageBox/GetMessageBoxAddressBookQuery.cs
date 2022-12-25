using System;

namespace Vulcanova.Uonet.Api.MessageBox
{
    public record GetMessageBoxAddressBookQuery(Guid Box) : IApiQuery<AddressBookEntry[]>
    {
        public const string ApiEndpoint = "mobile/messagebox/addressbook";
    }
}