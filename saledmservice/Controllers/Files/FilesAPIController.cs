using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Model.Request.Files;
using Model.Response.Files;
using static System.Net.Mime.MediaTypeNames;

namespace saledmservice.Controllers.Files
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesAPIController : Base
    {
        private IConfiguration Configuration;
        private IHostingEnvironment _hostingEnvironment;

        public FilesAPIController(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _hostingEnvironment = environment;
        }


        [HttpPost("Camera")]
        public async Task<dynamic> Camera([FromBody] dynamic data)
        {
            var res = new UploadRes();
            string path = Configuration["IMG_PATH"];
            

            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string x = Directory.GetCurrentDirectory();            

            try
            {
                CultureInfo culture = new CultureInfo("en-US");
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd", culture);
                path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                path = Path.Combine(path, strDateTime);

                //var uploads = Path.Combine(path, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                string strIMG = data.IMGPATH;

                string extension = ".png";
                string newFileName = Guid.NewGuid() + extension;
                string newPath = Path.Combine(path, newFileName);
                string resPath = strDateTime + "/" + newFileName;

                if (!String.IsNullOrEmpty(strIMG))
                {
                    strIMG = strIMG.Split(new char[] { ',' })[1];
                    byte[] mImageArr = Convert.FromBase64String(strIMG);
                    System.IO.FileStream mFile = new System.IO.FileStream(newPath, System.IO.FileMode.CreateNew);
                    mFile.Write(mImageArr, 0, mImageArr.Length);
                    mFile.Flush();
                    mFile.Close();
                    mFile.Dispose();

                    res.fullpath = newPath;
                    res.path = resPath;
                    res._result._code = "200";
                    res._result._message = "";
                    res._result._status = "OK";

                }
                else
                {
                    res._result._code = "204";
                    res._result._message = "";
                    res._result._status = "No Content";
                }

               
            }
            catch (Exception ex)
            {
                res._result._code = "500 ";
                res._result._message = ex.Message;
                res._result._status = "Internal Server Error";

            }


            return res;

        }


        [HttpPost("GetImage")] //download
        public async Task<dynamic> GetImage([FromBody] dynamic data)
        {
            string path = Configuration["IMG_PATH"];
            CultureInfo culture = new CultureInfo("en-US");
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd", culture);
            path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            path = Path.Combine(path, strDateTime);

            FilesReq dataReq = new FilesReq();
            dataReq.fileName = data != null ? data.fileName : null;
            dataReq.path = data != null ? data.path : path;
            dataReq.fullpath = data != null ? data.fullpath : null;
            if (String.IsNullOrEmpty(dataReq.fullpath))
            {
                dataReq.file = Path.Combine(dataReq.path, dataReq.fileName);
            }
            else
            {
                dataReq.file = Path.Combine(dataReq.fullpath);
            }


            byte[] imageByteData = System.IO.File.ReadAllBytes(dataReq.file);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);

            return imageDataURL;

        }


        [HttpPost("GetFile")] //download
        public async Task<dynamic> GetFile([FromBody] dynamic data)
        {
            string path = Configuration["IMG_PATH"];
            FilesReq dataReq = new FilesReq();
            dataReq.fileName = data != null ? data.fileName : null;
            dataReq.path = data != null ? data.path : path;
            dataReq.fullpath = data != null ? data.fullpath : null;
            if (String.IsNullOrEmpty(dataReq.fullpath))
            {
                dataReq.file = Path.Combine(dataReq.path, dataReq.fileName);
            }
            else
            {
                dataReq.file = Path.Combine(dataReq.fullpath);
            }


            return new FileStream(dataReq.file, FileMode.Open, FileAccess.Read);
        }


        [HttpPost("DownloadFile")] //download
        public async Task<dynamic> DownloadFile([FromBody] dynamic data)
        {

            FilesReq dataReq = new FilesReq();
            dataReq.fileName = data != null ? data.fileName : null;
            dataReq.path = data != null && data.path ? data.path : Configuration["IMG_PATH"];
            dataReq.file = Path.Combine(dataReq.path, dataReq.fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(dataReq.file, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(dataReq.file), dataReq.fileName);

        }



        [HttpPost("upload")]
        public async Task<dynamic> Upload(IFormFile file)
        {
            var res = new UploadRes();
            FilesReq dataReq = new FilesReq();



            try
            {
                dataReq.path = Configuration["IMG_PATH"];

                var uploads = Path.Combine(dataReq.path, "uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                dataReq.path = uploads;

                if (file != null && file.Length > 0)
                {
                    var filePath = Path.Combine(dataReq.path, file.FileName);

                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = Guid.NewGuid() + extension;
                    string newPath = Path.Combine(dataReq.path, newFileName);
                    using (var fileStream = new FileStream(newPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    res._result._code = "200";
                    res._result._message = "";
                    res._result._status = "OK";

                    res.fileName = newFileName;
                    res.path = dataReq.path;
                    res.fullpath = newPath;



                }
                else
                {
                    res._result._code = "204";
                    res._result._message = "";
                    res._result._status = "No Content";
                }


            }
            catch (Exception ex)
            {
                res._result._code = "415 ";
                res._result._message = ex.Message;
                res._result._status = "Unsupported Media Type";
            }

            return res;
        }


        [HttpPost("FileUpload")]
        public async Task<object> FileUpload()
        {
            var httpRequest = HttpContext.Request;
            var imageUrls = string.Empty;
            var fileName = string.Empty;
            FilesReq dataReq = new FilesReq();
            var res = new UploadRes();

            try
            {
                dataReq.path = Configuration["IMG_PATH"];

                var uploads = Path.Combine(dataReq.path, "uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                dataReq.path = uploads;

                if (httpRequest.Form.Files.Count > 0)
                {
                    for (var f = 0; f < httpRequest.Form.Files.Count; f++)
                    {
                        var postedFile = httpRequest.Form.Files[f];
                        var files = new List<IFormFile>();
                        files.Add(postedFile);

                        foreach (var file in files)
                        {
                            fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName.ToString().Trim('"');
                            var fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                            var randomFileName = System.DateTime.Now.Ticks.ToString();
                            var finalFileName = randomFileName + fileExtension;
                            string newPath = Path.Combine(dataReq.path, finalFileName);

                            using (var fileStream = new FileStream(newPath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            res._result._code = "200";
                            res._result._message = "";
                            res._result._status = "OK";

                            res.fileName = finalFileName;
                            res.path = dataReq.path;
                            res.fullpath = newPath;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                res._result._code = "415 ";
                res._result._message = ex.Message;
                res._result._status = "Unsupported Media Type";
            }
            return res;

        }


        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
