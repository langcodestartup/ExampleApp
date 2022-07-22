using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


JsonSerializer Serializer = new JsonSerializer();
CosmosClient client;
Container container;
Database database = null;
int itemsToCreate = 10;
int itemSize;
int runtimeInSeconds = 1;
bool shouldCleanupOnFinish;
int numWorkers = 10;

string endpoint = "https://spin-invoice-cosmos.documents.azure.com:443/";
string authKey = "VH1cGoiUNQSrgLhTj7kcYXN9nckJ6rTjYl2vZv7GcJHKUEQlvE6X7QlskOVPSZkEUzjdQj4Alx6omvZXTPiQCg==";

client = new CosmosClient(endpoint, authKey, new CosmosClientOptions() { AllowBulkExecution = true });
container = client.GetContainer("main", "test");

Stopwatch stopwatch = Stopwatch.StartNew();
long startMilliseconds = stopwatch.ElapsedMilliseconds;

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(runtimeInSeconds * 1000);
CancellationToken cancellationToken = cancellationTokenSource.Token;

int created = 0;
try
{
    List<Task> workerTasks = new List<Task>();
    for (int i = 0; i < numWorkers; i++)
    {
        Test? t = new() { id = Guid.NewGuid().ToString(), Name = "a" };
        workerTasks.Add(container.CreateItemAsync(t, new PartitionKey(t.id)));
        //workerTasks.Add(Task.Run(() =>
        //{
        //    Test? t = new() { Name ="a"};
        //    _ = container.CreateItemAsync(t, new PartitionKey(Guid.NewGuid().ToString()), null, cancellationToken)
        //    .ContinueWith((task) => {
        //        Console.WriteLine("만들기");
        //        if(task.IsCompletedSuccessfully)
        //        {
        //            t = null;
        //            var code = task.Result.StatusCode;
        //            if (code == HttpStatusCode.Created)
        //                created++;
        //        }
        //        task.Dispose();
        //    });
            
        //}));
    }

    await Task.WhenAll(workerTasks);
}
catch (Exception ex)
{

}
Console.WriteLine($"Inserted {created} items in {(stopwatch.ElapsedMilliseconds - startMilliseconds) / 1000} seconds");
Console.ReadKey();



public class Test
{
    public string id { get; set; } = "";
    public string Name { get; set; } = "";
    public string ClassType { get; set; } = "TEST";

}