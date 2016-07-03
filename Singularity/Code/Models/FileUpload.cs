﻿
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;


using LCore.Extensions;
using Singularity.Context;
using Singularity.Extensions;

namespace Singularity.Models
    {
    public class FileUpload : IModel
        {
        [Key]
        public int FileUploadID { get; set; }

        public DateTime Created { get; set; }
        public bool Active { get; set; }

        public string FilePath { get; set; }

        public int FileSize { get; set; }

        public int RelationID { get; set; }
        public string RelationType { get; set; }
        public string RelationProperty { get; set; }

        public byte[] GetCloudBytes()
            {
            return ContextProviderFactory.GetCurrent().GetFileUploadCloudContainer().DownloadFile(this.FilePath);
            }

        public FileUpload()
            {
            }

        public FileUpload(string RelationType, string RelationProperty, int RelationID)
            {
            this.RelationType = RelationType;
            this.RelationProperty = RelationProperty;
            this.RelationID = RelationID;
            }

        public FileUpload(byte[] FileBytes, string FullPath)
            {
            this.Created = DateTime.Now;
            this.Active = true;

            this.FileSize = FileBytes.Length;

            this.FilePath = FullPath;

            System.IO.File.WriteAllBytes(this.FilePath, FileBytes);
            }

        public FileUpload(HttpPostedFileBase File, CloudBlobDirectory Dir, string FileName)
            {
            this.Created = DateTime.Now;
            this.Active = true;

            this.FileSize = File.ContentLength;

            this.FilePath = FileName;

            Dir.UploadFile(File.InputStream, FileName);
            }



        public static FileUpload FindFileUpload(ModelContext DbContext, int FileID, Type t)
            {
            var File = DbContext.GetDBSet<FileUpload>().FirstOrDefault(
                f => f.Active &&
                    f.RelationType == t.FullName &&
                    f.FileUploadID == FileID);

            return File;
            }

        public static IQueryable<FileUpload> GetFileUploads(ModelContext DbContext, IModel Model, string Property = null)
            {
            string ID = Model.GetID();
            int IntID = Convert.ToInt32(ID);
            string Type = Model.TrueModelType().FullName;

            return DbContext.GetDBSet<FileUpload>().Where(
                f => f.Active &&
                f.RelationID == IntID &&
                f.RelationType == Type &&
                    (Property == null ||
                    f.RelationProperty == Property));
            }
        }
    }
