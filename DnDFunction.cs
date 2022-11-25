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
}


