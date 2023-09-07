<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Text.Json</Namespace>
</Query>

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Text.Json;

void Main()
{
	using HttpClient client = new();
	client.DefaultRequestHeaders.Accept.Clear();
	client.DefaultRequestHeaders.Accept.Add(
		new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
	client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
	/*client.DefaultRequestHeaders.Authorization =
	new AuthenticationHeaderValue("Bearer", "<my token>");*/
	


	//Task<string> json = client.GetStringAsync("https://api.github.com/users/christianpopescu/repos");
	 
	//-- get private, meeaning all repositories of the authenticated user
	//Task<Stream> streamJson = client.GetStreamAsync("https://api.github.com/user/repos?per_page=100");
	
	// Get al the repositories of the given user
	Task<Stream> streamJson = client.GetStreamAsync("https://api.github.com/users/christianpopescu/repos?per_page=100");
	Stream s = streamJson.Result;
	ValueTask<List<Repository>> tl = JsonSerializer.DeserializeAsync<List<Repository>>(s);

	foreach (var repo in tl.Result ?? Enumerable.Empty<Repository>())
		Console.WriteLine(repo.name + "                               " + repo.full_name);
}


public record class Repository(string name, string full_name);
// You can define other methods, fields, classes and namespaces here