using AutoMapper;
using BurgerApp.BLL.ViewModels.General_Models;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.BLL.ViewModels.Other_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;
using BurgerApp.PL.ViewModels;

namespace BurgerApp.PL.Areas.Admin.Profiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region BurgerProfile
            CreateMap<BurgerViewModel, BurgerDTO>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)));


            CreateMap<BurgerDTO, BurgerViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)));

            #endregion

            #region CipsProfile
            CreateMap<CipsViewModel, CipsDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<CipsDTO, CipsViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));



            CreateMap<DrinkViewModel, DrinkDTO>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)));

            CreateMap<DrinkDTO, DrinkViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)));

            #endregion
            #region SauceProfile
            CreateMap<SauceViewModel, SauceDTO>()
                     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)))
                     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<SauceDTO, SauceViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            #endregion
            #region SauceProfile
            CreateMap<ExtraMaterialViewModel, ExtraMaterialDTO>()
                     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)))
                     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<ExtraMaterialDTO, ExtraMaterialViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            #endregion

            #region MenuProfile

            CreateMap<MenuViewModel, MenuDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DrinkId, opt => opt.MapFrom(src => src.DrinkId))
                    .ForMember(dest => dest.BurgerId, opt => opt.MapFrom(src => src.BurgerId))
                    .ForMember(dest => dest.CipsId, opt => opt.MapFrom(src => src.CipsId))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)));


            CreateMap<MenuDTO, MenuViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DrinkId, opt => opt.MapFrom(src => src.DrinkId))
                    .ForMember(dest => dest.BurgerId, opt => opt.MapFrom(src => src.BurgerId))
                    .ForMember(dest => dest.CipsId, opt => opt.MapFrom(src => src.CipsId))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image)));

            #endregion
            #region OrderDetailProfile

            CreateMap<OrderDetailViewModel, OrderDetailDTO>()
                .ForMember(dest => dest.BurgerId, opt => opt.MapFrom(src => src.BurgerId))
                .ForMember(dest => dest.DrinkId, opt => opt.MapFrom(src => src.DrinkId))
                .ForMember(dest => dest.CipsId, opt => opt.MapFrom(src => src.CipsId))
                .ForMember(dest => dest.Sauces, opt => opt.MapFrom(src => src.Sauces))
                .ForMember(dest => dest.ExtraMetarials, opt => opt.MapFrom(src => src.ExtraMetarials))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.IsSell, opt => opt.MapFrom(src => src.IsSell));
            CreateMap<OrderDetailDTO, OrderDetailViewModel>()
                .ForMember(dest => dest.BurgerId, opt => opt.MapFrom(src => src.BurgerId))
                .ForMember(dest => dest.DrinkId, opt => opt.MapFrom(src => src.DrinkId))
                .ForMember(dest => dest.CipsId, opt => opt.MapFrom(src => src.CipsId))
                .ForMember(dest => dest.Sauces, opt => opt.MapFrom(src => src.Sauces))
                .ForMember(dest => dest.ExtraMetarials, opt => opt.MapFrom(src => src.ExtraMetarials))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.IsSell, opt => opt.MapFrom(src => src.IsSell));
            #endregion

        }
    }
}
