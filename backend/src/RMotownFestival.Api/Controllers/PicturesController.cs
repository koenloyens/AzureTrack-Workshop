using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RMotownFestival.Api.Common;
using System.Linq;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {

        public BlobUtility BlobUtility { get; }

        private readonly IConfiguration Configuration;

        public PicturesController(BlobUtility blobUtility, IConfiguration configuration)
        {
            BlobUtility = blobUtility;
            Configuration = configuration;
        }

        [HttpGet]
        public string[] GetAllPictureUrls()
        {
            BlobContainerClient container = BlobUtility.GetThumbsContainer();

            return container.GetBlobs()
                            .Select(blob => BlobUtility.GetSasUri(container, blob.Name))
                            .ToArray();
        }


        [HttpPost]
        public void PostPicture(IFormFile file)
        {
            BlobContainerClient container = BlobUtility.GetThumbsContainer();
            container.UploadBlob(file.FileName, file.OpenReadStream());
        }
    }
}
