using MVCL;
using MVCL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MVCL.Models
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

        public FileUpload()
            {
            }

        public FileUpload(String RelationType, String RelationProperty, int RelationID)
            {
            this.RelationType = RelationType;
            this.RelationProperty = RelationProperty;
            this.RelationID = RelationID;
            }

        public FileUpload(HttpPostedFileBase File, String FullPath)
            {
            Created = DateTime.Now;
            Active = true;

            FileSize = File.ContentLength;

            FilePath = FullPath;

            // No buffered read or write.
            Byte[] Bytes = new Byte[File.ContentLength];

            File.InputStream.Read(Bytes, 0, File.ContentLength);

            System.IO.File.WriteAllBytes(FilePath, Bytes);
            }
        }
    }
