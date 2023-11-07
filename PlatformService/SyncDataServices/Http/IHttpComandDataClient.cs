using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public interface IHttpComandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}