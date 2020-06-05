using AutoMapper;
using DropZone.Core.Models;
using DropZone.Database.Models;

namespace DropZone.Core
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<AAD, AADModel>()
                .ForMember(x => x.HashBlock, opt => opt.Ignore())
                .ForMember(x => x.ParachuteSystem, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AADType, AADTypeModel>()
                .ForMember(x => x.Manufacturer, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Aircraft, AircraftModel>()
                .ForMember(x => x.DropZone, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Database.Models.DropZone, DropZoneModel>()
                .ForMember(x => x.Aircrafts, opt => opt.Ignore())
                .ForMember(x => x.Users, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<HashBlock, HashBlockModel>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.PreviousHashBlock, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Jump, JumpModel>()
                .ForMember(x => x.JumpBook, opt => opt.Ignore())
                .ForMember(x => x.DropZone, opt => opt.Ignore())
                .ForMember(x => x.ParachuteSystem, opt => opt.Ignore())
                .ForMember(x => x.Aircraft, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<JumpBook, JumpBookModel>()
                .ForMember(x => x.Sportsman, opt => opt.Ignore())
                .ForMember(x => x.Jumps, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Parachute, ParachuteModel>()
                .ForMember(x => x.Manufacturer, opt => opt.Ignore())
                .ForMember(x => x.HashBlock, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ParachuteSystem, ParachuteSystemModel>()
                .ForMember(x => x.MainParachute, opt => opt.Ignore())
                .ForMember(x => x.ReserveParachute, opt => opt.Ignore())
                .ForMember(x => x.AAD, opt => opt.Ignore())
                .ForMember(x => x.Satchel, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.HashBlock, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Role, RoleModel>()
                .ForMember(x => x.Users, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Satchel, SatchelModel>()
                .ForMember(x => x.Manufacturer, opt => opt.Ignore())
                .ForMember(x => x.HashBlock, opt => opt.Ignore())
                .ForMember(x => x.ParachuteSystem, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ForMember(x => x.Role, opt => opt.Ignore())
                .ForMember(x => x.DropZone, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
