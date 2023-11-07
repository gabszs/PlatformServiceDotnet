using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PlatformService.Data;
using FakeItEasy;
using PlatformService.Dtos;
using PlatformService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;

namespace PlatformService.Tests.Systems.Controllers
{
    internal class MockPlatformControllerTests
    {
        public class MockPlatformsControllerTests
        {
            //private readonly IPlatformRepo _platformRepository;
            //private readonly IMapper _mapper;

            //public MockPlatformsControllerTests()
            //{
            //    _platformRepository = A.Fake<IPlatformRepo>();
            //    _mapper = A.Fake<IMapper>();
            //}

            //[Fact]
            //public async void PlatformController_GetPlatforms_ReturnOk()
            //{
            //    var platforms = A.Fake<IEnumerable<PlatformReadDto>>();
            //    var platformIEnumerable = A.Fake<IEnumerable<PlatformReadDto>>();

            //    // A.CallTo(() => _platformRepository.GetAllPlatforms()).Returns(platforms);
            //    A.CallTo(() => _mapper.Map<IEnumerable<PlatformReadDto>>(platforms))
            //        .Returns(platformIEnumerable);

            //    var controller = new PlatformsController(_platformRepository, _mapper);

            //    var result = await controller.GetPlatforms();

            //    result.Should().NotBeNull();
            //    result.Should().BeOfType(typeof(OkObjectResult));

            // }



        }
    }
}
