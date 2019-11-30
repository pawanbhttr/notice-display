using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Display.Web.Models
{
    public class CarouselModel
    {
        public int CarouselID { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool Active { get; set; }
    }
}