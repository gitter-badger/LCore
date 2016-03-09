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
    public class AzureInterface
        {
        public const String ConnectionStringName = "BlobConnection";

        public static CloudStorageAccount GetStorageAccount()
            {
            return CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
            }
        }
    }