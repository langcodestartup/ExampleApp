using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

string connectstring = "DefaultEndpointsProtocol=https;AccountName=spininvoicestorage;AccountKey=KgL7nes7uwlWxwFgY+lTnP7jplC4XODicr7jOXpr+BVemaJ6LAS7GTSuJGmU6XiuoI04nSPyXCyD+AStrxpU4g==;EndpointSuffix=core.windows.net";
string filepath = @"C:\Users\김수현.AzureAD\Downloads\제목 없음.png";
//BlobServiceClient BlobServiceClient = new BlobServiceClient(connectstring);
//BlobContainerClient BlobContainerClient = BlobServiceClient.GetBlobContainerClient("excel");
//BlobClient BlobClient = BlobContainerClient.GetBlobClient("abc.png");
//await BlobClient.UploadAsync(filepath);
//Console.WriteLine("완료");

//string sas = "https://spininvoicestorage.blob.core.windows.net/excel?sp=racwd&st=2022-07-12T09:56:03Z&se=2022-07-12T17:56:03Z&spr=https&sv=2021-06-08&sr=c&sig=8WkCyfzO%2FRlhBbOBaoXIEisiJlEcVbSWx9s8c6ot6LI%3D";
//BlobContainerClient BlobContainerClient2 = new BlobContainerClient(new Uri(sas));
//BlobClient BlobClient = BlobContainerClient2.GetBlobClient("abc2.png");
//await BlobClient.UploadAsync(filepath);
//Console.WriteLine("완료");


BlobServiceClient BlobServiceClient3 = new BlobServiceClient(connectstring);
var BlobContainerClient3 = BlobServiceClient3.GetBlobContainerClient("excel");
if (!BlobContainerClient3.CanGenerateSasUri) return;

// Create a SAS token that's valid for one hour.
BlobSasBuilder sasBuilder = new BlobSasBuilder()
{
    BlobContainerName = BlobContainerClient3.Name,
    Resource = "c"
};

sasBuilder.StartsOn = DateTimeOffset.UtcNow.AddMinutes(-1);
sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
sasBuilder.SetPermissions(BlobContainerSasPermissions.All);

Uri sasUri = BlobContainerClient3.GenerateSasUri(sasBuilder);

Stream stream = File.OpenRead(filepath);
BlobContainerClient BlobContainerClient4 = new BlobContainerClient(sasUri);
BlobClient BlobClient = BlobContainerClient4.GetBlobClient("abc3.png");
await BlobClient.UploadAsync(stream);
Console.WriteLine("완료");