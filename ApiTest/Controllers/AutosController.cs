using System.Web.Http;

namespace ApiTest.Controllers
{
    public class AutosController : ApiController
    {
        private ApiManager.Autos _autosManager;

        private ApiManager.Autos AutosManager => _autosManager ?? (_autosManager = new ApiManager.Autos());

        [HttpGet, Route("autos/Brands")]
        public IHttpActionResult GetBrands() => Ok(AutosManager.GetBrands());

        [HttpGet, Route("autos/Models/{brandName}")]
        public IHttpActionResult GetModels(string brandName) => Ok(AutosManager.GetModels(brandName));

        [HttpPost, Route("autos/Brands/{brandName}")]
        public IHttpActionResult AddBrand(string brandName) => Ok(AutosManager.AddBrand(brandName));

        [HttpPost, Route("autos/models/{brandName}/{modelName}/{average_price}")]
        public IHttpActionResult AddModel(string brandName, string modelName, int average_price) => Ok(AutosManager.AddModel(brandName, modelName, average_price));

        [HttpPut, Route("autos/models/{id}/{averagePrice}")]
        public IHttpActionResult UpdateModel(int id, int averagePrice) => Ok(AutosManager.UpdateModel(id, averagePrice));

        [HttpGet, Route("autos/models/{greater}/{lower}")]
        public IHttpActionResult Models(int greater = 0, int lower = 0) => Ok(AutosManager.Models(greater, lower));
    }
}