using FluentAssertions;
using Moq;
using RunpathApi.Controllers;
using RunpathApi.Data;
using RunpathApi.Models;
using RunpathApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static RunpathApi.Helpers.Constants;

namespace RunpathApi.Tests
{
    public class RetreivingPhotoAlbumsFeature
    {
        IDataService DataService { get; }

        IApiClient ApiClient { get; }

        public RetreivingPhotoAlbumsFeature()
        {
            var mock = new Mock<AlbumController>();

            ApiClient = new ApiClient();
            DataService = new DataService(ApiClient);

        }

        [Fact]
        public async Task RetreivePhotos()
        {
            var photosJson = await ApiClient.GetAsync<IEnumerable<Photo>>(PHOTOS_URL);

            Assert.NotNull(photosJson);

            var photosList = photosJson.Should().BeAssignableTo<IEnumerable<Photo>>().Subject;

            photosList.Count().Should().Be(5000);
        }

        [Fact]
        public async Task RetreiveAlbums()
        {
            var albumsJson = await ApiClient.GetAsync<IEnumerable<Album>>(ALBUMS_URL);

            Assert.NotNull(albumsJson);

            var albums = albumsJson.Should().BeAssignableTo<IEnumerable<Album>>().Subject;

            albums.Count().Should().Be(100);
        }

        [Fact]
        public async Task RetreiveAllPhotoAlbumsTest()
        {
            AlbumController albumController = new AlbumController(DataService);

            var photoAlbumsResult = await albumController.GetAllAlbums(null);

            Assert.NotNull(photoAlbumsResult);

            var albumJson = photoAlbumsResult.Should().BeOfType<List<PhotoAlbumModel>>().Subject;

            albumJson.Count().Should().Be(5000);
        }

        [Fact]
        public async Task RetreivePhotoAlbumsByUserIdTest()
        {
            AlbumController albumController = new AlbumController(DataService);

            var photoAlbumsResult = await albumController.GetAllAlbums(4);

            Assert.NotNull(photoAlbumsResult);

            var albumJson = photoAlbumsResult.Should().BeOfType<List<PhotoAlbumModel>>().Subject;

            albumJson.Count().Should().Be(500);

        }
    }
}
