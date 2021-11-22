using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Client.ApiServices
{
    public class ProductApiService : IProductApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            //_httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {

            ////////////////////////
            // WAY 1 :

            var httpClient = _httpClientFactory.CreateClient("ProductAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/catalog");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<Product>>(content);
            return productList;

            ////////////////////////// //////////////////////// ////////////////////////
            //// WAY 2 :

            //// 1. "retrieve" our api credentials. This must be registered on Identity Server!
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5009/connect/token",

            //    ClientId = "catalogClient",
            //    ClientSecret = "secret",

            //    // This is the scope our Protected API requires. 
            //    Scope = "catalogAPI"
            //};

            //// creates a new HttpClient to talk to our IdentityServer (localhost:5009)
            //var client = new HttpClient();

            //// just checks if we can reach the Discovery document. Not 100% needed but..
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5009");
            //if (disco.IsError)
            //{
            //    return null; // throw 500 error
            //}

            //// 2. Authenticates and get an access token from Identity Server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);            
            //if (tokenResponse.IsError)
            //{
            //    return null;
            //}

            //// Another HttpClient for talking now with our Protected API
            //var apiClient = new HttpClient();

            //// 3. Set the access_token in the request Authorization: Bearer <token>
            //client.SetBearerToken(tokenResponse.AccessToken);

            //// 4. Send a request to our Protected API
            //var response = await client.GetAsync("http://localhost:5000/api/v1/catalog");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //var productList = JsonConvert.DeserializeObject<List<Product>>(content);
            //return productList;


        }

        public Task<Product> GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserInfoViewModel> GetUserInfo()
        //{
        //    var idpClient = _httpClientFactory.CreateClient("IDPClient");

        //    var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

        //    if (metaDataResponse.IsError)
        //    {
        //        throw new HttpRequestException("Something went wrong while requesting the access token");
        //    }

        //    var accessToken = await _httpContextAccessor
        //        .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        //    var userInfoResponse = await idpClient.GetUserInfoAsync(
        //       new UserInfoRequest
        //       {
        //           Address = metaDataResponse.UserInfoEndpoint,
        //           Token = accessToken
        //       });

        //    if (userInfoResponse.IsError)
        //    {
        //        throw new HttpRequestException("Something went wrong while getting user info");
        //    }

        //    var userInfoDictionary = new Dictionary<string, string>();

        //    foreach (var claim in userInfoResponse.Claims)
        //    {
        //        userInfoDictionary.Add(claim.Type, claim.Value);
        //    }

        //    return new UserInfoViewModel(userInfoDictionary);
        //}
    }
}