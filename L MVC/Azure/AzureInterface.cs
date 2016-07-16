using System;
using System.Configuration;
using Microsoft.WindowsAzure;

namespace Singularity.Azure
    {
    public class AzureInterface
        {
        public const string ConnectionStringName = "BlobConnection";

        public static CloudStorageAccount GetStorageAccount()
            {
            return CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
            }
        }
    }