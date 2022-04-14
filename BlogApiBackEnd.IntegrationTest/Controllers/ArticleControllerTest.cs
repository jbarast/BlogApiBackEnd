using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using BlogApiBackEnd.Domain.Entities;
using BlogApiBackEnd.Infrastructure.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using System.Threading.Tasks;
using BlogApiBackEnd.Domain.Contracts.DomainService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BlogApiBackEnd.Domain.Contracts.DomainService;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;


namespace BlogApiBackEnd.IntegrationTest.Controllers
{
    public class ArticleControllerTest
    {
        [Fact]
        public async Task Test1()
        {
            var webHostBuilder = new WebHostBuilder()
                .ConfigureAppConfiguration(x=> x.AddJsonFile("appsettings.test.json",optional:true))
                .ConfigureTestServices(collection =>
                {
                    // collection.RemoveAll<IDsArticle>();
                    // collection.AddScoped<IDsArticle, Mock<IDsArticle> >();
                })
                .UseStartup<Startup>();

            using (var server = new TestServer(webHostBuilder))
            {
                // Codigo
                HttpClient client = server.CreateClient();

                var result = await client.GetFromJsonAsync<List<Article>>("/Article"
                    , new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });

                
                Assert.NotNull(result);
                Assert.IsType<List<Article>>(result);
                
                client.Dispose();
            }
        }
        
        
    }
    
    
}