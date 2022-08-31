﻿using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetlistBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;

            public GetlistBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);
                BrandListModel mappedBrandListModel = _mapper.Map<BrandListModel>(brands);
                return mappedBrandListModel;
            }
        }
    }
}
