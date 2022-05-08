using System.Security.Cryptography.X509Certificates;
using Vulcanova.Uonet;
using Vulcanova.Uonet.Api;
using Vulcanova.Uonet.Api.Auth;
using Vulcanova.Uonet.Api.Common;
using Vulcanova.Uonet.Api.Grades;
using Vulcanova.Uonet.Crypto;
using Vulcanova.Uonet.Firebase;
using Vulcanova.Uonet.Signing;

// Setup request signer
var firebaseToken = await FirebaseTokenFetcher.FetchFirebaseTokenAsync();
var (pk, cert) = KeyPairGenerator.GenerateKeyPair();

var x509Cert2 = new X509Certificate2(cert.GetEncoded());

var requestSigner = new RequestSigner(x509Cert2.Thumbprint, pk, firebaseToken);

// Register client
Console.Write("Token: ");
var token = Console.ReadLine();

Console.Write("Symbol: ");
var symbol = Console.ReadLine();

Console.Write("PIN: ");
var pin = Console.ReadLine();

var instanceUrlProvider = new InstanceUrlProvider();

var apiClient = new ApiClient(requestSigner, await instanceUrlProvider.GetInstanceUrlAsync(token, symbol));

var request = new RegisterClientRequest
{
    OS = Constants.AppOs,
    DeviceModel = Constants.DeviceModel,
    Certificate = Convert.ToBase64String(x509Cert2.RawData),
    CertificateType = "X509",
    CertificateThumbprint = x509Cert2.Thumbprint,
    PIN = pin,
    SecurityToken = token,
    SelfIdentifier = Guid.NewGuid().ToString()
};

await apiClient.PostAsync(RegisterClientRequest.ApiEndpoint, request);

var registerHebeResponse = await apiClient.GetAsync(RegisterHebeClientQuery.ApiEndpoint, new RegisterHebeClientQuery());

var firstAccount = registerHebeResponse.Envelope[0];

Console.WriteLine($"Unit name: {firstAccount.Unit.Name}");

// Switch to unit API
var unitApiClient = new ApiClient(requestSigner, firstAccount.Unit.RestUrl.ToString());

// Fetch grades
var gradesResponse = await unitApiClient.GetAllAsync(GetGradesByPupilQuery.ApiEndpoint, new GetGradesByPupilQuery(
        firstAccount.Unit.Id,
        firstAccount.Pupil.Id,
        firstAccount.Periods.Single(p => p.Current).Id,
        DateTime.MinValue,
        500))
    .ToListAsync();

foreach (var group in gradesResponse.GroupBy(g => g.Column.Subject.Id))
{
    var subjectName = group.First().Column.Subject.Name;

    Console.WriteLine($"{subjectName}: {string.Join(',', group.Select(g => g.ContentRaw))}");
}
