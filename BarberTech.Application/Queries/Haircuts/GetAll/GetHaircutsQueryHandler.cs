﻿using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryHandler : IRequestHandler<GetHaircutsQuery, IEnumerable<GetHaircutsQueryResponse>>
    {
        private readonly IHaircutRepository _haircutRepository;

        public GetHaircutsQueryHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<IEnumerable<GetHaircutsQueryResponse>> Handle(GetHaircutsQuery request, CancellationToken cancellationToken)
        {
            var haircuts = await _haircutRepository.GetAllAsync();

            return haircuts.Select(haircut => new GetHaircutsQueryResponse
            {
                Id = haircut.Id,
                Name = haircut.Name,
                Description = haircut.Description,
                ImageSource = haircut.ImageSource,
                Price = haircut.Price,
            });
        }
    }
}