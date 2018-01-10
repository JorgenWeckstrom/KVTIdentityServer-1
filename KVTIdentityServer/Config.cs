using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test; 
    

namespace TestingKVTIdenityserver
{
    public class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser{
                    SubjectId ="1",
                    Username= "jaya",
                    Password="myname",
                    Claims = new List<Claim> {
                         new Claim(IdentityModel.JwtClaimTypes.Email, "jayapradhareddy@gmail.com"),
                             new Claim(JwtClaimTypes.Role, "admin")

                }
                }
            };
        
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{
                    ClientId="winclient",
                    ClientName="Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = new List<string>{
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "customAPI"
                    },
                    //RedirectUris = new List<string> { "http://localhost:8000/dashboard/callback" },
                    //AccessTokenType = AccessTokenType.Jwt,
                    //AllowAccessTokensViaBrowser = true,
                },

                new Client{
                    ClientId = "React",
                    ClientName = "React Client",
                    Enabled = true,

                    AllowedGrantTypes = GrantTypes.Implicit, 
                    
                    PostLogoutRedirectUris = { "http://localhost:8000/dashboard/callback" },
                    AllowedCorsOrigins = { "http://localhost:8000" },
                    ClientSecrets = { new Secret("secretreact".Sha256()) },
                    AllowedScopes = new List<string>{
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api1"
                    },
                    RedirectUris = new List<string> { "http://localhost:8000/dashboard/callback" },
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowAccessTokensViaBrowser = true,
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
             return new List<ApiResource>
             {
                new ApiResource
                {
                    Name ="customAPI",
                    DisplayName="customAPI",
                    Description="Custom API Access",
                    UserClaims=new List<string> {"role"},
                    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                    Scopes = new List<Scope> {
                        new Scope(IdentityServerConstants.StandardScopes.OpenId),
                        new Scope("customAPI"),
                        new Scope("api1"),           
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}