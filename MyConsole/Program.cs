using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Storage.Blobs;


string connectstring = "DefaultEndpointsProtocol=https;AccountName=spininvoicestorage;AccountKey=KgL7nes7uwlWxwFgY+lTnP7jplC4XODicr7jOXpr+BVemaJ6LAS7GTSuJGmU6XiuoI04nSPyXCyD+AStrxpU4g==;EndpointSuffix=core.windows.net";
string filepath = @"C:\Users\김수현.AzureAD\Downloads\제목 없음.png";
BlobServiceClient BlobServiceClient = new BlobServiceClient(connectstring);
BlobContainerClient BlobContainerClient = BlobServiceClient.GetBlobContainerClient("excel");
BlobClient BlobClient = BlobContainerClient.GetBlobClient("abc.png");
await BlobClient.UploadAsync(filepath);
Console.WriteLine("완료");