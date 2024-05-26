using AutoMapper;
using GameEngine.DAL.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngines.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly AppDbContext ctx = null!;
        protected readonly IMapper mapper;
        protected readonly ILogger logger;

        public BaseService(AppDbContext ctx, IMapper mapper, ILogger logger)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.logger = logger;
        }
    }
}
