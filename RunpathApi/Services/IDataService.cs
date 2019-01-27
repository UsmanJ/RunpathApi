using RunpathApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunpathApi.Services
{
    public interface IDataService
    {
        Task<List<PhotoAlbumModel>> GetPhotoAlbums(int? userId);
    }
}
