using AutoMapper;
using RealState.Entity;
using RealState.ViewModels.BuyerViewModels;
using RealState.ViewModels.SellerViewModels;

namespace RealState.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
      

        CreateMap<CreateBuyerViewModel, Buyer>();

        CreateMap<CreateSellerViewModel, Seller>();
    }
}
