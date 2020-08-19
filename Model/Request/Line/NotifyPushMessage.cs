using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request.Line
{
    public class NotifyPushMessage
    {
        public string type { get; set; }
        public string message { get; set; }
        public string imageFullsize { get; set; }
        public string imageThumbnail { get; set; }
        public string stickerPackageId { get; set; }
        public string stickerId { get; set; }
        public string token { get; set; }
    }
}
