using Microsoft.AspNetCore.Mvc;
using RunpathApi.Models;
using RunpathApi.Routing;
using RunpathApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunpathApi.Controllers
{
    [Route(Routes.Album)]
    public class AlbumController : Controller
    {
        public IDataService DataService { get; }

        public AlbumController(IDataService dataService)
        {
            DataService = dataService;
        }

        [HttpGet]
        public async Task<List<PhotoAlbumModel>> GetAllAlbums(
            [FromQuery] int? userId)
        {
            var photoAlbums = await DataService.GetPhotoAlbums(userId);
            return photoAlbums;
        }
    }
}
