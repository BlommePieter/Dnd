namespace MCT.Function;

public class DnDFunctions
{

    [FunctionName("GetClasses")]
    public static async Task<IActionResult> GetClasses(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "classes")] HttpRequest req,
        ILogger log)
    {
        try
        {
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_CLASSES);

            string sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<Class>(sql);
            var results = new List<Class>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }

    [FunctionName("GetSpells")]
    public static async Task<IActionResult> GetSpells(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "spells")] HttpRequest req,
        ILogger log)
    {
        try
        {
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_SPELLS);

            string sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<Spell>(sql);
            var results = new List<Spell>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }

    [FunctionName("GetItems")]
    public static async Task<IActionResult> GetItems(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "items")] HttpRequest req,
        ILogger log)
    {
        try
        {
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_ITEMS);

            string sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<Item>(sql);
            var results = new List<Item>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }

    [FunctionName("GetWeapons")]
    public static async Task<IActionResult> GetWeapons(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "weapons")] HttpRequest req,
        ILogger log)
    {
        try
        {
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_WEAPONS);

            string sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<Weapon>(sql);
            var results = new List<Weapon>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }

    [FunctionName("GetArmors")]
    public static async Task<IActionResult> GetArmors(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "armors")] HttpRequest req,
        ILogger log)
    {
        try
        {
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_ARMOR);

            string sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<Armor>(sql);
            var results = new List<Armor>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }

    [FunctionName("AddClass")]
    public static async Task<IActionResult> AddClass(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "classes")] HttpRequest req,
        ILogger log)
    {
        try
        {
            // body uitlezen en omzetten naar Person object
            var json = await new StreamReader(req.Body).ReadToEndAsync();
            var task = JsonConvert.DeserializeObject<Class>(json);

            // connectie maken met CosmosDb
            var ConnectionString = Environment.GetEnvironmentVariable("CosmosDb");

            CosmosClientOptions options = new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            };

            CosmosClient client = new CosmosClient(ConnectionString, options);
            var container = client.GetContainer(General.COSMOS_DB_DND, General.COSMOS_CONTAINER_CLASSES);
            task.Id = Guid.NewGuid().ToString();
            await container.CreateItemAsync(task, new PartitionKey(task.Id));

            return new OkObjectResult(task);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new BadRequestObjectResult(ex.Message);
        }

    }
}


