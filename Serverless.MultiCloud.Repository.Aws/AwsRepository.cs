using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Serverless.MultiCloud.Domain.Abstractions;
using Serverless.MultiCloud.Repository.Abstractions;

namespace Serverless.MultiCloud.Repository.Aws
{
    public class AwsRepository : IRepository<DomainEntity>
    {
        private readonly string _tableName;
        private readonly ILogger<AwsRepository> _logger;
        private readonly IAmazonDynamoDB _client;

        public AwsRepository(
            IAmazonDynamoDB client,
            IOptions<AwsRepositoryConfiguration> options
            , ILogger<AwsRepository> logger
            )
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _tableName = options?.Value?.MessagesTableName ?? throw new ArgumentNullException("Messages table");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> SaveAsync(DomainEntity item)
        {
            string newId = Guid.NewGuid().ToString();

            _logger.LogInformation($@"Saving domain entity:
    MESSAGE: {item.Message}
    NEW-ID: {newId}
    TABLE-NAME: {_tableName}");

            var request = new PutItemRequest()
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>()
                {
                    {"id", new AttributeValue() { S = newId } }
                    ,{"message", new AttributeValue() { S = item.Message } }
                }
            };
            await _client.PutItemAsync(request);

            return newId;
        }
    }
}
