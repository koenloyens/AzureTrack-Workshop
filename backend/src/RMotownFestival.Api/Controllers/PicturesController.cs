using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {


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
        }
    }
}
