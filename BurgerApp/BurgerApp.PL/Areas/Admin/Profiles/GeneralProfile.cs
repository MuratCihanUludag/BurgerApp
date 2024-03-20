﻿using AutoMapper;
using BurgerApp.BLL.ViewModels.Menu_Models;
using BurgerApp.PL.Areas.Admin.Models.MenuViewModel;
using BurgerApp.PL.CommonFunctions;

namespace BurgerApp.PL.Areas.Admin.Profiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region BurgerProfile
            CreateMap<BurgerViewModel, BurgerDTO>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ImageToArray(src.Image)));

            CreateMap<BurgerDTO, BurgerViewModel>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.Image, opt => opt.MapFrom(src => CommonFunc.ArrayToImage(src.Image))); 
            #endregion
        }
    }
}