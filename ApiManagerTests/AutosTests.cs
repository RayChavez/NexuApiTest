using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Tests
{
    [TestClass()]
    public class AutosTests
    {
        [TestMethod()]
        public void GetBrandsTest()
        {
            var result = new ApiManager.Autos().GetBrands();
            Assert.IsFalse(result.ToList().Count == 0);
        }

        [TestMethod()]
        public void GetModelsTest()
        {
            var result = new ApiManager.Autos().GetModels("Acura");
            Assert.IsFalse(result.ToList().Count == 0);
        }
    }
}