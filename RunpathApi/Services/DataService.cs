using RunpathApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunpathApi.Data;
using static RunpathApi.Helpers.Constants;

namespace RunpathApi.Services
{
    public class DataService : IDataService
    {
        public DataService(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        public IApiClient ApiClient { get; }

        public async Task<List<PhotoAlbumModel>> GetPhotoAlbums(int? userId)
        {
            var photos = await ApiClient.GetAsync<IEnumerable<Photo>>(PHOTOS_URL);
            var albums = await ApiClient.GetAsync<IEnumerable<Album>>(ALBUMS_URL);

            var photoAlbums = from p in photos
                join a in albums on p.AlbumId equals a.Id
                select new PhotoAlbumModel
                {
                    Id = p.Id,
                    AlbumId = a.Id,
                    AlbumTitle = a.Title,
                    PhotoTitle = p.Title,
                    UserId = a.UserId,
                    ThumbnailUrl = p.ThumbnailUrl,
                    Url = p.Url
                };

            if (userId != null)
            {
                var filteredPhotoAlbums = photoAlbums.Where(o => o.UserId == userId);
                return filteredPhotoAlbums.ToList();
            }

            return photoAlbums.ToList();
        }
    }
}


