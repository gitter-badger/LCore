using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Singularity.Azure
    {
    public class AzureBlobInterface
        {
        public static CloudBlobClient GetBlobClient()
            {
            CloudStorageAccount StorageAccount = AzureInterface.GetStorageAccount();

            CloudBlobClient BlobClient = StorageAccount.CreateCloudBlobClient();

            return BlobClient;
            }

        public static CloudBlobContainer GetContainer(String ContainerName)
            {
            CloudBlobClient Client = GetBlobClient();

            CloudBlobContainer Container = Client.GetContainerReference(ContainerName);
            Container.CreateIfNotExist();

            return Container;
            }

        public static CloudBlobDirectory GetContainerDirectory(String ContainerName, String DirName)
            {
            CloudBlobContainer Container = GetContainer(ContainerName);

            CloudBlobDirectory FilesDir = Container.GetDirectoryReference(DirName);

            return FilesDir;
            }
        }
    }