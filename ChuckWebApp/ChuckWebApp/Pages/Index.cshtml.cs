using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using System.Threading;
using Azure;
using Microsoft.Extensions.Primitives;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System.Text;
using Microsoft.Azure.KeyVault.Models;

namespace ChuckWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private static IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public async Task OnGetAsync()
        {
            
            // Store secret information
            string MyCert = "";

            // Store Key Vault URI for connection
            var _keyVaultName = $"https://keytest-vault.vault.azure.net/";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var _client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            // Causes Error in Azure
            var _sec = await _client.GetSecretAsync(_keyVaultName, "ExampleSecret");
            MyCert += "Sectret Name: " + _sec.SecretIdentifier.Name + "\n";
            MyCert += "Secret Value: " + _sec.Value + "\n";

            ViewData["Message"] = "My key val = " + MyCert;
        }
    }
}
