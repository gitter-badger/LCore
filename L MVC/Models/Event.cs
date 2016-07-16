using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity.Annotations;

namespace Singularity.Models
    {
    [Table("Events")]
    [DisplayColumn("Date", "Date", true)]
    public class Event : IModel
        {
        public enum MasterType
            {
            Users,
            Role,
            WorkSite,
            Notification,
            Report
            }

        [Key]
        public int EventID { get; set; }

        public int? RecordID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Date { get; set; }
        public string Action { get; set; }

        [HideManageViewColumn]
        public string Details { get; set; }

        public string Page { get; set; }

        [HideManageViewColumn]
        public string OldEntryXML { get; set; }
        [HideManageViewColumn]
        public string NewEntryXML { get; set; }

        public Event()
            {
            }
        public Event(int EventID, int RecordID, int UserID, DateTime Date, string Action, string Details, string Page, string OldXML, string NewXml)
            {
            this.EventID = EventID;
            this.RecordID = RecordID;
            this.UserID = UserID;
            this.Date = Date;
            this.Action = Action;
            this.Details = Details;
            this.Page = Page;

            this.OldEntryXML = OldXML;
            this.NewEntryXML = NewXml;
            }
        }
    }