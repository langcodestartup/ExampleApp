using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Storage.Blobs;


string connectstring = "DefaultEndpointsProtocol=https;AccountName=spininvoicestorage;AccountKey=KgL7nes7uwlWxwFgY+lTnP7jplC4XODicr7jOXpr+BVemaJ6LAS7GTSuJGmU6XiuoI04nSPyXCyD+AStrxpU4g==;EndpointSuffix=core.windows.net";
string filepath = @"C:\Users\김수현.AzureAD\Downloads\제목 없음.png";
//BlobServiceClient BlobServiceClient = new BlobServiceClient(connectstring);
//BlobContainerClient BlobContainerClient = BlobServiceClient.GetBlobContainerClient("excel");
//BlobClient BlobClient = BlobContainerClient.GetBlobClient("abc.png");
//await BlobClient.UploadAsync(filepath);
//Console.WriteLine("완료");

string sas = "https://spininvoicestorage.blob.core.windows.net/excel?sp=racwd&st=2022-07-12T09:56:03Z&se=2022-07-12T17:56:03Z&spr=https&sv=2021-06-08&sr=c&sig=8WkCyfzO%2FRlhBbOBaoXIEisiJlEcVbSWx9s8c6ot6LI%3D";
BlobContainerClient BlobContainerClient2 = new BlobContainerClient(new Uri(sas));
BlobClient BlobClient = BlobContainerClient2.GetBlobClient("abc2.png");
await BlobClient.UploadAsync(filepath);
Console.WriteLine("완료");