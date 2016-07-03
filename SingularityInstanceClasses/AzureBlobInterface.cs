using System;
using Microsoft.WindowsAzure.StorageClient;
using Singularity.Azure;

namespace SingularityInstanceClasses
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

    public class RosieBlobInterface : AzureBlobInterface
        {
        public static readonly bool SaveLocalFiles = false;

        public enum RosieFileType
            {
            Normal,
            SignedContract,
            SendContract,
            TimeSheet,
            SharedPDF
            }

        /////////////////////////////////////////////////////////////////////

        public const string RosieContainer_Files = "rosie-files";

        public const string RosieFolder_Files = "files";
        public const string RosieFolder_SignedContracts = "signed-contracts";
        public const string RosieFolder_SendContracts = "send-contracts";
        public const string RosieFolder_TimeSheets = "time-sheets";
        public const string RosieFolder_Shared = "shared";
        public const string RosieFolder_FileUploads = "file-uploads";

        /////////////////////////////////////////////////////////////////////

        public const string RosieContainer_Processing = "rosie-process";

        public const string RosieContainer_SQLExport = "automated-sql-export";

        public const string RosieFolder_PayStubCSV = "pay-stub-csv";

        /////////////////////////////////////////////////////////////////////

        public static CloudBlobDirectory GetDirectory_FileUploads()
            {
            return GetContainerDirectory(RosieContainer_Files, RosieFolder_FileUploads);
            }

        /////////////////////////////////////////////////////////////////////
        }
    }