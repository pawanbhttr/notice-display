using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Display.Web.Models
{
    public class NoticeModel
    {
        public int NoticeID { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool Active { get; set; }
    }
}