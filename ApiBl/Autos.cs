using ApiDal;
using ApiDal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ApiBl
{
    public class Autos
    {
        public IEnumerable<eAuto> Brands()
        {
            using (var dc = new nexudbEntities1())
            {
                var result = from autos in dc.Autos
                             group autos by autos.brand_name into autosgroup
                             select new eAuto { average_price = (int)autosgroup.Average(x => x.average_price), brand_name = autosgroup.Key };

                return result.Select(n => new eAuto { average_price = n.average_price, brand_name = n.brand_name }).ToList();
            }
        }

        public IEnumerable<eAuto> Models(string brandName)
        {
            using (var dc = new nexudbEntities1())
            {
                return dc.Autos.Where(x => x.brand_name == brandName).Select(x => new eAuto { id = x.id, name = x.name, average_price = (int)x.average_price }).ToList();
            }
        }

        public ResponseMessage addBrand(string brandName)
        {
            var result = new ResponseMessage { Code = 0, Message = "Se guardo la información correctamente.", Status = true };

            using (var dc = new nexudbEntities1())
            {
                var existe = dc.Autos.FirstOrDefault(x => x.brand_name == brandName);
                if (existe == null)
                {
                    var newAuto = new Auto { average_price = 0, brand_name = brandName, name = "N/A" };
                    dc.Autos.Add(newAuto);
                    dc.SaveChanges();
                    return result;
                }
                result.Code = 100;
                result.Message = "Ya existe la marca que esta intentando agregar.";
                result.Status = false;
            }
            return result;
        }

        public ResponseMessage AddModel(string brandName, string modelName, int average_price = 0)
        {
            var result = new ResponseMessage { Code = 0, Message = "Se guardo la información correctamente.", Status = true };

            if (average_price > 0 && average_price <= 100000)
            {
                result.Code = 300;
                result.Message = "El precio proporcinado debe de ser mayor a $ 100,000.";
                result.Status = false;
                return result;
            }
            using (var dc = new nexudbEntities1())
            {
                var existe = dc.Autos.FirstOrDefault(x => x.name == modelName);
                if (existe != null)
                {
                    result.Code = 100;
                    result.Message = "No existe la marca solicitada, favor de agregarla previamente.";
                    result.Status = false;
                    return result;
                }
                var existeModel = dc.Autos.FirstOrDefault(x => x.name == modelName && x.brand_name == brandName);
                if (existeModel != null)
                {
                    result.Code = 200;
                    result.Message = "El modelo solicitado ya existe.";
                    result.Status = false;
                    return result;
                }
                var newAuto = new Auto { average_price = 0, brand_name = brandName, name = modelName };
                dc.Autos.Add(newAuto);
                dc.SaveChanges();
                return result;
            }
        }

        public ResponseMessage updateModel(int id, int average_price)
        {
            var result = new ResponseMessage { Code = 0, Message = "Se guardo la información correctamente.", Status = true };

            if (average_price > 0 && average_price <= 100000)
            {
                result.Code = 300;
                result.Message = "El precio proporcinado debe de ser mayor a $ 100,000.";
                result.Status = false;
                return result;
            }

            using (var dc = new nexudbEntities1())
            {
                var existe = dc.Autos.FirstOrDefault(x => x.id == id);
                if (existe != null)
                {
                    existe.average_price = average_price;
                    dc.SaveChanges();
                    return result;
                }
                result.Code = 100;
                result.Message = "No existe el modelo que quiere editar.";
                result.Status = false;
            }
            return result;
        }

        public IEnumerable<eAuto> Models(int greater = 0, int lower = 0)
        {
            using (var dc = new nexudbEntities1())
            {
                var result = dc.Autos.Where(n=>n.id > 0);
                if (greater > 0)
                    result = result.Where(x => x.average_price > greater);
                if (lower > 0)
                    result = result.Where(x => x.average_price < lower);

                return result.Select(n => new eAuto { average_price = (int)n.average_price, brand_name = n.brand_name }).ToList();
            }
        }
    }
}