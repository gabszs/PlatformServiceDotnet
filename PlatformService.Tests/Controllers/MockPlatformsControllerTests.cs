using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Controllers;
using PlatformService.Data;
using PlatformService.Dtos;
using Xunit;

namespace PlatformService.Tests.Controllers
{
    // class MockPlatformsControllerTests
    // {
    //     private readonly IPlatformRepo _platformRepository;
    //     private readonly IMapper _mapper;

    //     public MockPlatformsControllerTests()
    //     {
    //         _platformRepository = A.Fake<IPlatformRepo>();
    //         _mapper = A.Fake<IMapper>();
    //     }

    //     [Fact]
    //     public async void PlatformController_GetPlatforms_ReturnOk()
    //     {
    //         var platforms = A.Fake<IEnumerable<PlatformReadDto>>();
    //         var platformIEnumerable = A.Fake<IEnumerable<PlatformReadDto>>();

    //         // A.CallTo(() => _platformRepository.GetAllPlatforms()).Returns(platforms);
    //         A.CallTo(() => _mapper.Map<IEnumerable<PlatformReadDto>>(platforms))
    //             .Returns(platformIEnumerable);

    //         var controller = new PlatformsController(_platformRepository, _mapper);

    //         var result = await controller.GetAllPlatforms();

    //         result.Should().NotBeNull();
    //         result.Should().BeOfType(typeof(OkObjectResult));
        
    //     }

        

    // }
}
