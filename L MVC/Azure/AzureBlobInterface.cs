using System;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public class AzureBlobInterface
        {
        public static CloudBlobClient GetBlobClient()
            {
            var StorageAccount = AzureInterface.GetStorageAccount();

            var BlobClient = StorageAccount.CreateCloudBlobClient();

            return BlobClient;
            }

        public static CloudBlobContainer GetContainer(string ContainerName)
            {
            var Client = GetBlobClient();

            var Container = Client.GetContainerReference(ContainerName);
            Container.CreateIfNotExist();

            return Container;
            }

        public static CloudBlobDirectory GetContainerDirectory(string ContainerName, string DirName)
            {
            var Container = GetContainer(ContainerName);

            var FilesDir = Container.GetDirectoryReference(DirName);

            return FilesDir;
            }
        }
    }