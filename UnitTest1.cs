using NUnit.Framework;
using RestSharp;

namespace RestSharpDemo
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var content = client.Execute(request).Content;
            Assert.IsNotNull(content);
        }
    }
}