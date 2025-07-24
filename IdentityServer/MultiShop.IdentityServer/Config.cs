// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources=>new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={ "DiscountFullPermission", "DiscountReadPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission","OrderReadPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission","CargoReadPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission","BasketReadPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources=>new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes=>new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Reading Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("DiscountReadPermission","Reading Authority For Discount Operations"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("OrderReadPermission","Reading Authority For Order Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("CargoReadPermission","Reading Authority For Cargo Operations"),
            new ApiScope("BasketPermission","Full Authority For Basket Operations"),
            new ApiScope("BasketReadPermission","Reading Authority For Basket Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients=>new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission","BasketReadPermission"},
                AccessTokenLifetime=600
            },
            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "DiscountReadPermission", "OrderReadPermission", "CargoReadPermission","BasketReadPermission" },
                AccessTokenLifetime=600
            },
            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    },
                AccessTokenLifetime=600
            }
        };
    }
}