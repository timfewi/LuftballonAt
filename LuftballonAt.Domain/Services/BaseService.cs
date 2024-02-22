using AutoMapper;
using LuftballonAt.Domain.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IServiceProvider? _serviceProvider;
        protected readonly ILogger? _logger;
        protected readonly IConfiguration? _configuration;
        protected readonly IUnitOfWork? _unitOfWork;
        protected readonly IMapper? _mapper;


        public BaseService(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
            _mapper = (IMapper?)_serviceProvider.GetService(typeof(IMapper));
            _logger = (ILogger?)_serviceProvider.GetService(typeof(ILogger));
            _configuration = (IConfiguration?)_serviceProvider.GetService(typeof(IConfiguration));
            _unitOfWork = (IUnitOfWork?)_serviceProvider.GetService(typeof(IUnitOfWork));

        }
    }
}
