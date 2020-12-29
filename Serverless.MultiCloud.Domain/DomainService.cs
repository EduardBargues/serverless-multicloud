using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Serverless.MultiCloud.Domain.Abstractions;
using Serverless.MultiCloud.Repository.Abstractions;

namespace Serverless.MultiCloud.Domain
{
    public class DomainService : IDomainService
    {
        private readonly IRepository<DomainEntity> _repository;
        private readonly ILogger<DomainService> _logger;
        public DomainService(
            IRepository<DomainEntity> repository
            , ILogger<DomainService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> DoDomainActionAsync()
        {
            var domainEntity = new DomainEntity() { Message = $"This message was saved at {DateTime.Now}" };
            return await _repository.SaveAsync(domainEntity);
        }
    }
}
