﻿using AutoMapper;
using RealState.Entity;
using RealState.ViewModels.BuyerViewModels;
using RealState.ViewModels.FSBOViewModels;
using RealState.ViewModels.PortfolioViewModels;
using RealState.ViewModels.QuestViewModels;
using RealState.ViewModels.SellerViewModels;

namespace RealState.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBuyerViewModel, Buyer>().ReverseMap();
        CreateMap<ResultBuyerViewModel, Buyer>().ReverseMap();

        CreateMap<CreateSellerViewModel, Seller>().ReverseMap();
        CreateMap<ResultSellerViewModel, Seller>().ReverseMap();

        CreateMap<CreatePortfolioViewModel, Portfolio>().ReverseMap();

        CreateMap<CreateQuestViewModel, Quest>().ReverseMap();

        CreateMap<CreateFSBOViewModel, FSBO>().ReverseMap();
    }
}
