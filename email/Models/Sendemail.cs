using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace email.Models
{
    public class Sendemail
    {
        public String To { get; set; }
        public String From { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public HttpPostedFileBase fileUploader { get; set; }

    }
}