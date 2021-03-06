using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   //new Client
                   //{
                   //     ClientId = "basketClient",
                   //     AllowedGrantTypes = GrantTypes.ClientCredentials,
                   //     ClientSecrets =
                   //     {
                   //         new Secret("secret".Sha256())
                   //     },
                   //     AllowedScopes = { "basketAPI" }
                   //},
                   //new Client
                   //{
                   //     ClientId = "orderingClient",
                   //     AllowedGrantTypes = GrantTypes.ClientCredentials,
                   //     ClientSecrets =
                   //     {
                   //         new Secret("secret".Sha256())
                   //     },
                   //     AllowedScopes = { "orderingAPI" }
                   //},
                   new Client
                   {
                        ClientId = "catalogClient",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "catalogAPI" }
                   },
                   new Client
                   {
                       ClientId = "shop_mvc_client",
                       ClientName = "Catalog MVC Web App",
                       AllowedGrantTypes = GrantTypes.Code,
                       //RequirePkce = false,
                       AllowRememberConsent = false,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5009/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5009/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.Address,
                           IdentityServerConstants.StandardScopes.Email,
                           "catalogAPI",
                           "roles"
                       }
                   }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               //new ApiScope("basketAPI", "Basket API"),
               new ApiScope("catalogAPI", "Catalog API"),
               //new ApiScope("orderingAPI", "Ordering API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
               //new ApiResource("basketAPI", "Basket API"),
               new ApiResource("catalogAPI", "Catalog API"),
               //new ApiResource("orderingAPI", "Ordering API")
          };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
          };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "admin",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "admin"),
                        new Claim(JwtClaimTypes.FamilyName, "adminovich")
                    }
                }
            };
    }
}