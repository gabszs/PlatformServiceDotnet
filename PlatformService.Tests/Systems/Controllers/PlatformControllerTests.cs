using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using PlatformService.Controllers;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace PlatformService.Tests.Systems.Controllers
{
    [TestClass]
    public class PlatformsControllerTests
    {
        [TestMethod]
        public async void GetPlatforms_OnSuccess_ReturnsStatus200()
        {
            var expectedPlatforms = new List<Platform>
            {
                new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            };
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(stringResult);
            var actualPlatforms = JsonConvert.DeserializeObject<List<Platform>>(stringResult);
            CollectionAssert.AreEqual(expectedPlatforms, actualPlatforms);
            //Assert.AreEqual("", stringResult);
        }
    }
}
