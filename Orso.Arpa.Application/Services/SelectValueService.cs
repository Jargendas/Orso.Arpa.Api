using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Orso.Arpa.Application.Dtos;
using Orso.Arpa.Application.Interfaces;
using Orso.Arpa.Domain.Entities;

namespace Orso.Arpa.Application.Services
{
    public class SelectValueService : ISelectValueService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SelectValueService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<SelectValueDto>> GetAsync(string tableName, string propertyName)
        {
            IImmutableList<SelectValue> selectValues = await _mediator.Send(new List.Query(tableName, propertyName));
            return _mapper.Map<IEnumerable<SelectValueDto>>(selectValues);
        }
    }
}
