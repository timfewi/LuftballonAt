using AutoMapper;
using LuftballonAt.Domain.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ILogger<BaseService> _logger;
        protected readonly IConfiguration _configuration;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _mapper = _serviceProvider.GetService<IMapper>() ?? throw new InvalidOperationException("Mapper service not found.");
            _logger = _serviceProvider.GetService<ILogger<BaseService>>() ?? throw new InvalidOperationException("Logger service not found.");
            _configuration = _serviceProvider.GetService<IConfiguration>() ?? throw new InvalidOperationException("Configuration service not found.");
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>() ?? throw new InvalidOperationException("UnitOfWork service not found.");
        }
    }

}
