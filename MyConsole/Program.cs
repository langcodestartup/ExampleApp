using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using IronXL;

IronXL.License.LicenseKey = "IRONXL.DEVTEAM.IRO220217.4447.58105.712022-80F0F23D30-PP5DIUOGV3IDZ-NENU5DWCHIZ2-KG46JTKM23RN-3C76N4HA6OKJ-BIPRPKWWOPVH-WKINMP-LWAIZOI7X3SIUA-LITE.SUB-HLGHJD.RENEW.SUPPORT.17.FEB.2023";
string connectstring = "DefaultEndpointsProtocol=https;AccountName=spininvoicestorage;AccountKey=KgL7nes7uwlWxwFgY+lTnP7jplC4XODicr7jOXpr+BVemaJ6LAS7GTSuJGmU6XiuoI04nSPyXCyD+AStrxpU4g==;EndpointSuffix=core.windows.net";
BlobServiceClient BlobServiceClient3 = new BlobServiceClient(connectstring);
var BlobContainerClient3 = BlobServiceClient3.GetBlobContainerClient("testexcel");
var blob = BlobContainerClient3.GetBlobClient("test.csv");
var stream= await blob.OpenReadAsync();

try
{

	WorkBook workbook1 = WorkBook.Load(stream);

}
catch (Exception ex)
{

	throw;
}