using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Model.Request.Files
{
    public class FilesReq
    {
        public string fileName { get; set; }
        public string path { get; set; }
        public string fullpath { get; set; }
        public string file { get; set; }
        public IFormFile FileToUpload { get; set; }
    }
}
