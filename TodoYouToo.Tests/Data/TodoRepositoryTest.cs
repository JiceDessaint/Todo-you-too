using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoYouToo.Data;
using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Tests.Data
{
    [TestClass]
    public class TodoRepositoryTest
    {
        private TodoRepository GetInstance(IContext context)
        {
            return new TodoRepository(context);
        }

        [TestMethod]
        public void GetAll_WhenCalled_ShoudReturnDbSetOfTheContext()
        {
            // Arrange
            var dbset = new Mock<DbSet<TodoItem>>();
            var context = new Mock<IContext>();
            context.SetupGet(c => c.TodoItems).Returns(dbset.Object);
            var repo = this.GetInstance(context.Object);
            
            // Act
            var result = repo.GetAll();

            // Assert
            Assert.AreSame(dbset.Object, result);
        }

        [TestMethod]
        public void Add_WhenGivenAnItem_ShouldUpdateItsContext()
        {
            // Arrange
            var todoToAdd = new TodoItem();
            var dbset = new Mock<DbSet<TodoItem>>();
            var context = new Mock<IContext>();
            context.SetupGet(c => c.TodoItems).Returns(dbset.Object);
            var repo = this.GetInstance(context.Object);
            context.Setup(c => c.SaveChanges()).Callback(() => {
                dbset.Verify(d => d.Add(todoToAdd), Times.Once());
            });

            // Act
            repo.Add(todoToAdd);

            // Assert
            context.Verify(c => c.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Remove_WhenGivenAnItem_ShouldUpdateItsContext()
        {
            // Arrange
            var todoToRemove = new TodoItem();
            var dbset = new Mock<DbSet<TodoItem>>();
            var context = new Mock<IContext>();
            context.SetupGet(c => c.TodoItems).Returns(dbset.Object);
            var repo = this.GetInstance(context.Object);
            context.Setup(c => c.SaveChanges()).Callback(() =>
            {
                dbset.Verify(d => d.Remove(todoToRemove), Times.Once());
            });

            // Act
            repo.Remove(todoToRemove);

            // Assert
            context.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
