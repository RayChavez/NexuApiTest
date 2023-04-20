using ApiDal.Entities;
using System.Collections.Generic;

namespace ApiManager
{
    public class Autos
    {
        private ApiBl.Autos _autosBl;

        private ApiBl.Autos AutosBl => _autosBl ?? (_autosBl = new ApiBl.Autos());

        public IEnumerable<eAuto> GetBrands() => AutosBl.Brands();

        public IEnumerable<eAuto> GetModels(string brandName) => AutosBl.Models(brandName);

        public ResponseMessage AddBrand(string brandName) => AutosBl.addBrand(brandName);

        public ResponseMessage AddModel(string brandName, string modelName, int average_price = 0) => AutosBl.AddModel(brandName, modelName, average_price);

        public ResponseMessage UpdateModel(int id, int average_price = 0) => AutosBl.updateModel(id, average_price);

        public IEnumerable<eAuto> Models(int greater = 0, int lower = 0) => AutosBl.Models(greater, lower);
    }
}