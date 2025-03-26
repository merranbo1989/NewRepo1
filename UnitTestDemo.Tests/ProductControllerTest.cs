using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Controllers;
using UnitTestDemo.Models;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Test_Index_Returns_ProductCount()
        {
            var controller = new ProductController();
            var result = (controller.Index()) as ViewResult;
           var productList  = (List<Product>?)result?.ViewData.Model;
            Assert.Equal(3, productList?.Count);
        }
        [Fact]
        public void Test_Details_Returns_ViewName()
        {
            var controller = new ProductController();
            var result = controller.Details(2) as ViewResult;
            Assert.Equal("Details", result?.ViewName);
        }
        [Fact]
        public void Test_Details_ReturnsViewData()
        {
            var controller = new ProductController();
            var result = controller.Details(2) as ViewResult;
            var product = result?.ViewData.Model;
            Assert.Equal("Mobile", product?.ToString());
        }
        [Fact]
        public void Test_Details_RedirectToIndex_IfIdLessThanOne()
        {
            var controller = new ProductController();
            var result = (RedirectToActionResult)controller.Details(-1);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
