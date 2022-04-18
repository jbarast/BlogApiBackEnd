using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BlogApiBackEnd.Domain.Contracts;
using BlogApiBackEnd.Domain.Entities;
using Castle.Core.Logging;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace BlogApiBackEnd.DomainService.Test
{
    public class DsArticleTest
    {
        private readonly DsArticle _dsArticle;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<ILogger<DsArticle>> _loggerMock = new Mock<ILogger<DsArticle>>();

        public DsArticleTest()
        {
            _dsArticle = new DsArticle(_unitOfWorkMock.Object, _loggerMock.Object);
        }


        [Fact]
        public void GetAllArticle()
        {
            // Arrange
            // _unitOfWork.Articles.GetAll();
            List<Article> articlesMockList = new List<Article>();

            DateTime date01 = DateTime.Now;
            DateTime date02 = DateTime.Now.AddSeconds(10);

            articlesMockList.Add(new Article {Id = 1, Title = "Title01", Content = "Content 01", Date = date01});
            articlesMockList.Add(new Article {Id = 2, Title = "Title02", Content = "Content 02", Date = date02});

            _unitOfWorkMock.Setup(x => x.Articles.GetAll()).ReturnsAsync(articlesMockList);

            // Act
            var res = _dsArticle.Get().Result.ToArray();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(articlesMockList[0], res[0]);
            Assert.Equal(articlesMockList[1], res[1]);
        }

        [Fact]
        public void GetCertainArticle()
        {
            // Arrange
            List<Article> articlesMockList = new List<Article>();

            DateTime date01 = DateTime.Now;
            DateTime date02 = DateTime.Now.AddSeconds(10);

            articlesMockList.Add(new Article {Id = 1, Title = "Title01", Content = "Content 01", Date = date01});
            articlesMockList.Add(new Article {Id = 2, Title = "Title02", Content = "Content 02", Date = date02});

            // Expression<Func<string, bool>> testExpression = binding => (binding == "Testing Framework");
            Expression<Func<Article, bool>> expression = article => (article.Id == 1);


            _unitOfWorkMock.Setup(x => x.Articles.Get(expression)).ReturnsAsync(new List<Article>
            {
                articlesMockList[0]
            });

            // Act
            var res = _dsArticle.Get(expression).Result.ToList();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(1, res.Count());
            Assert.Equal(articlesMockList[0].Id, res[0].Id);
            Assert.Equal(articlesMockList[0].Date, res[0].Date);
            Assert.Equal(articlesMockList[0].Title, res[0].Title);
            Assert.Equal(articlesMockList[0].Content, res[0].Content);
        }
    }
}