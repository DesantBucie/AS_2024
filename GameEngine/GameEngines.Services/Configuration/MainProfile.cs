using AutoMapper;
using GameEngine.ViewModels.VM;
using GameEngine.Model;
using GameEngine.Model.DataModels;

namespace GameEngines.Services.Configuration.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile() { 
            CreateMap<Game, GameVm>()
                .ForMember(dest => dest.EngineName, x => x.MapFrom(src => src.Engine.Name == null ?
                "Unkown" : src.Engine.Name));
            CreateMap<AddOrUpdateGameVm, Game>();
            CreateMap<GameVm, AddOrUpdateGameVm>();


            CreateMap<Engine, EngineVm>();
            CreateMap<EngineVm, Engine>();
            CreateMap<AddOrUpdateEngineVm, Engine>();
            CreateMap<EngineVm, AddOrUpdateEngineVm>();
        }
    }
}
