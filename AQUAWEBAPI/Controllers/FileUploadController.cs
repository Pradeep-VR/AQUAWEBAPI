using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AQUAWEBAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/fileupload")]
        public async Task<HttpResponseMessage> FilePost()
        {
            /*var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                var filePath = "D:\\Pradeep\\uploads\\";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                using (var fs = new FileStream(filePath + file.FileName, FileMode.Create))
                {
                    await file.InputStream.CopyToAsync(fs);
                }

                return Request.CreateResponse(HttpStatusCode.Created, "File uploaded successfully.");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded.");*/
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                //var filePath = "D:\\Pradeep\\uploads\\";

                string filePath = System.Configuration.ConfigurationManager.AppSettings["fileupload"];

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                using (var fileStream = new FileStream(filePath + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    await file.InputStream.CopyToAsync(fileStream);
                }

                return Request.CreateResponse(HttpStatusCode.Created, "File uploaded successfully.");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded.");
        }
    }
}
