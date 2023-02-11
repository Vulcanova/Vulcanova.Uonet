using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vulcanova.Uonet.Signing
{
    public class ContextualRequestSigner : RequestSigner
    {
        private readonly string _context;

        public ContextualRequestSigner(string fingerprint, string privateKey, string firebaseToken, string context) :
            base(fingerprint, privateKey, firebaseToken)
        {
            _context = context;
        }

        public override async ValueTask<Dictionary<string, string>> CreateSignedHeaders(string body, string fullUrl)
        {
            var headers = await base.CreateSignedHeaders(body, fullUrl);
            
            headers["vContext"] = _context;

            return headers;
        }
    }
}