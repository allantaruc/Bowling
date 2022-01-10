using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Bowling.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bowling.Data
{
    public class GameRepo : IGameRepo
    {
        private readonly IAmazonDynamoDB _dynamoDB;
        public GameRepo()
        {
            _dynamoDB = CreateClient();
        }
        public async Task<List<Game>> GetGamesAsync()
        {

            var result = await _dynamoDB.ScanAsync(new ScanRequest
            {
                TableName = "games"
            });

            if (result != null && result.Items != null)
            {
                var games = new List<Game>();
                foreach (var item in result.Items)
                {
                    item.TryGetValue("id", out var id);
                    item.TryGetValue("name", out var name);

                    games.Add(new Game
                    {
                        Id = int.Parse(id?.N),
                        Name = name?.S
                    });
                }
                return games;
            }

            return null;
        }

        public async Task<Game> GetGameAsync(int id)
        {
            var request = new GetItemRequest("games", new Dictionary<string, AttributeValue>() { { "id", new AttributeValue { N = $"{id}" } } });
            var result = await _dynamoDB.GetItemAsync(request);

            if (result != null && result.Item != null && result.Item.Count != 0)
            {
                result.Item.TryGetValue("id", out var gameid);
                result.Item.TryGetValue("name", out var name);

                return new Game
                {
                    Id = int.Parse(gameid?.N),
                    Name = name?.S
                };

            }
            return null;
        }

        public async Task CreateAsync(Game game)
        {
            var request = new PutItemRequest
            {
                TableName = "games",
                Item = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue{N = game.Id.ToString() } },
                    { "name", new AttributeValue{S = game.Name } }
                }
            };
            var response = await _dynamoDB.PutItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }

        public async Task UpdateAsync(Game game)
        {
            var request = new PutItemRequest
            {
                TableName = "games",
                Item = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue{N = game.Id.ToString() } },
                    { "name", new AttributeValue{S = game.Name } }
                }
            };
            var response = await _dynamoDB.PutItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }

        public async Task DeleteAsync(int id)
        {
            var request = new DeleteItemRequest
            {
                TableName = "games",
                Key = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue { N = id.ToString() } }
                }
            };
            var response = await _dynamoDB.DeleteItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }



        public async Task CreateShotAsync(Shot shot)
        {
            var request = new PutItemRequest
            {
                TableName = "shots",
                Item = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue{N = shot.Id.ToString() } },
                    { "gameId", new AttributeValue{N = shot.GameId.ToString() } },
                    { "pins_knocked_down", new AttributeValue{N = shot.PinsKnockedDown.ToString() } }
                }
            };
            var response = await _dynamoDB.PutItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }

        public async Task UpdateShotAsync(Shot shot)
        {
            var request = new PutItemRequest
            {
                TableName = "shots",
                Item = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue{N = shot.Id.ToString() } },
                    { "gameId", new AttributeValue{N = shot.GameId.ToString() } },
                    { "pins_knocked_down", new AttributeValue{N = shot.PinsKnockedDown.ToString() } }
                }
            };
            var response = await _dynamoDB.PutItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }

        public async Task DeleteShotAsync(int gameId, int id)
        {
            var request = new DeleteItemRequest
            {
                TableName = "shots",
                Key = new Dictionary<string, AttributeValue> {
                    { "id", new AttributeValue { N = id.ToString() } },
                    { "gameId", new AttributeValue { N = gameId.ToString() } },
                }
            };
            var response = await _dynamoDB.DeleteItemAsync(request);
            if (response.HttpStatusCode != HttpStatusCode.OK) throw new ApplicationException($"{response.HttpStatusCode}");
        }


        public async Task<List<Shot>> GetAllShotsAsync(int gameId)
        {
            var request = new QueryRequest
            {
                TableName = "shots",
                QueryFilter = new Dictionary<string, Condition> {
                    { "gameId", new Condition {  } }
                }
            };
            //_dynamoDB.QueryAsync
            var result = await _dynamoDB.ScanAsync(new ScanRequest
            {
                TableName = "shots",

            });

            if (result != null && result.Items != null)
            {
                var shots = new List<Shot>();
                foreach (var item in result.Items)
                {
                    item.TryGetValue("id", out var id);
                    item.TryGetValue("gameId", out var GameId);
                    item.TryGetValue("pins_knocked_down", out var pinsKnockedDown);

                    shots.Add(new Shot
                    {
                        Id = int.Parse(id?.N),
                        GameId = int.Parse(GameId?.N),
                        PinsKnockedDown = int.Parse(pinsKnockedDown?.N)
                    });
                }
                return shots;
            }

            return null;
        }

        public async Task<Game> GetShotAsync(int id)
        {
            var request = new GetItemRequest("games", new Dictionary<string, AttributeValue>() { { "id", new AttributeValue { N = $"{id}" } } });
            var result = await _dynamoDB.GetItemAsync(request);

            if (result != null && result.Item != null && result.Item.Count != 0)
            {
                result.Item.TryGetValue("id", out var gameid);
                result.Item.TryGetValue("name", out var name);

                return new Game
                {
                    Id = int.Parse(gameid?.N),
                    Name = name?.S
                };

            }
            return null;
        }
        private static AmazonDynamoDBClient CreateClient()
        {
            var dynamoDbConfig = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.USEast2
            };
            var awsCredentials = new AwsCredentials();
            return new AmazonDynamoDBClient(awsCredentials, dynamoDbConfig);
        }
    }

    public class AwsCredentials : AWSCredentials
    {
        public override ImmutableCredentials GetCredentials()
        {
            return new ImmutableCredentials("", "", null);
        }
    }
}