// https://zetcode.com/csharp/httpclient/

using System.Net.Http.Headers;
using Newtonsoft.Json;

using var client = new HttpClient();

client.BaseAddress = new Uri("https://api.github.com");
client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
var url = "https://leijnse.info/hyperlinks/rest/Restcontroller.php/?command=allmysql&count=900&from=0&search=Luzern";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();
var resp = await response.Content.ReadAsStringAsync();  
List<Hyperlink> contributors = JsonConvert.DeserializeObject<List<Hyperlink>>(resp);
contributors.ForEach(Console.WriteLine);
Console.WriteLine("end run");

record Hyperlink(long ID, string group, string category, string webdescription, string website);