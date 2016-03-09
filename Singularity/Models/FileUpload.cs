
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;
using Microsoft.WindowsAzure.StorageClient;

using LCore;

using Singularity;
using Singularity.Context;
using Singularity.Extensions;

namespace Singularity.Models
    {
    public class FileUpload : IModel
        {
        [Key]
        public int FileUploadID { get; set; }

        public DateTime Created { get; set; }
        public Boolean Active { get; set; }

        public String FilePath { get; set; }

        public int FileSize { get; set; }

        public int RelationID { get; set; }
        public String RelationType { get; set; }
        public String RelationProperty { get; set; }

        public Byte[] GetCloudBytes()
            {
            return ContextProviderFactory.GetCurrent().GetFileUploadCloudContainer().DownloadFile(this.FilePath);
            }

        public FileUpload()
            {
            }

        public FileUpload(String RelationType, String RelationProperty, int RelationID)
            {
            this.RelationType = RelationType;
            this.RelationProperty = RelationProperty;
            this.RelationID = RelationID;
            }

        public FileUpload(Byte[] FileBytes, String FullPath)
            {
            Created = DateTime.Now;
            Active = true;

            FileSize = FileBytes.Length;

            FilePath = FullPath;

            System.IO.File.WriteAllBytes(FilePath, FileBytes);
            }

        public FileUpload(HttpPostedFileBase File, CloudBlobDirectory Dir, String FileName)
            {
            Created = DateTime.Now;
            Active = true;

            FileSize = File.ContentLength;

            FilePath = FileName;

            Dir.UploadFile(File.InputStream, FileName);
            }



        public static Singularity.Models.FileUpload FindFileUpload(ModelContext DbContext, int FileID, Type t)
            {
            Singularity.Models.FileUpload File = DbContext.GetDBSet<FileUpload>().Where(
                f => f.Active == true &&
                    f.RelationType == t.FullName &&
                    f.FileUploadID == FileID).FirstOrDefault();

            return File;
            }

        public static IQueryable<FileUpload> GetFileUploads(ModelContext DbContext, IModel Model, String Property = null)
            {
            String ID = Model.GetID();
            int IntID = Convert.ToInt32(ID);
            String Type = Model.TrueModelType().FullName;

            return DbContext.GetDBSet<FileUpload>().Where(
                f => f.Active &&
                f.RelationID == IntID &&
                f.RelationType == Type &&
                    (Property == null ||
                    f.RelationProperty == Property));
            }
        }
    }
