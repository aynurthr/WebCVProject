using MediatR;

namespace WebCV.Application.Modules.ServicesModule.Queries.ServiceGetAllQuery
{
    public class ServiceGetAllRequest : IRequest<IEnumerable<ServiceGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
