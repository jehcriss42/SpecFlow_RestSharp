using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Model;

namespace RestSharpDemo
{
    public class Tests
    {
        [Test]
        public void TestGetmethod()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);  

            var response = client.Execute(request);

            JObject values = JObject.Parse(response.Content);
            var author = values["author"].ToString();

            Assert.That(author, Is.EqualTo("typicode"), "Author not correct");
        }

        [Test]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.POST);
            request.AddUrlSegment("postid", 1);
            request.AddJsonBody(new { name = "Jess" });

            var response = client.Execute(request);

            JObject values = JObject.Parse(response.Content);
            var name = values["name"].ToString();

            Assert.That(name, Is.EqualTo("Jess"), "name not correct");
        }

        [Test]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts", Method.POST);
            request.AddJsonBody(new Posts() { id = "13", author="Execute automation", title = "RestSharp demo" });

            var response = client.Execute(request);

            JObject values = JObject.Parse(response.Content);
            var author = values["author"].ToString();

            Assert.That(author, Is.EqualTo("Execute automation"), "name not correct");
        }

    }
}