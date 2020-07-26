using AutoMapper;
using Purkki.MediatorPublicIdExample.Application.Cars.Commands.CreateCar;
using Purkki.MediatorPublicIdExample.Application.Cars.Commands.UpdateCar;
using Purkki.MediatorPublicIdExample.Persistence.Entities;

namespace Purkki.MediatorPublicIdExample.Application.Cars
{
	public class CarMappingProfile : Profile
	{
		public CarMappingProfile()
		{
			CreateMap<Car, CarDto>()
				.ForMember(dto => dto.Id, options => options.MapFrom(entity => entity.PublicId));

			CreateMap<CreateCarCommand, Car>();

			CreateMap<UpdateCarCommand, Car>()
				.ForMember(entity => entity.Id, options => options.Ignore());
		}
	}
}
