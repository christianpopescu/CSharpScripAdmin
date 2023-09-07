<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

void Main()
{
	using HttpClient client = new();
	client.DefaultRequestHeaders.Accept.Clear();
	client.DefaultRequestHeaders.Accept.Add(
		new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
	client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


	 Task<string> json = client.GetStringAsync("https://api.github.com/users/christianpopescu/repos");

	Console.Write(json.Result);
}

// You can define other methods, fields, classes and namespaces here