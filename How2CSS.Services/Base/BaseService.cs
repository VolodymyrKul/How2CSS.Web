using AutoMapper;
using How2CSS.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Services.Base
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
