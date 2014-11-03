using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoYouToo.Data;
using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Tests.ViewModels
{
    [TestClass]
    public class MainViewModelTest
    {
        private MainViewModel GetInstance()
        {
            return new MainViewModel(new Mock<IAddTodoPopup>().Object, new Mock<ITodoRepository>().Object);
        }
        private MainViewModel GetInstance(IAddTodoPopup AddTodoPopup, ITodoRepository TodoRepository)
        {
            return new MainViewModel(AddTodoPopup, TodoRepository);
        }

        [TestMethod]
        public void Constructor_WhenCalled_SetupInitialViewModel()
        {
            // Arrange
            var AddTodoPopup = new Mock<IAddTodoPopup>();
            var TodoRepository = new Mock<ITodoRepository>();
            // Act
            var result = this.GetInstance(AddTodoPopup.Object, TodoRepository.Object);

            // Assert
            Assert.AreSame(result.AddTodoPopup, AddTodoPopup.Object);
            AddTodoPopup.VerifySet(obj => obj.RootVM = result, Times.Once());
            Assert.IsNotNull(result.TodoItems);
            Assert.IsFalse(result.IsAddPopupVisible);
        }

        [TestMethod]
        public void Constructor_WhenCalled_LoadInitialData()
        {
            // Arrange
            var AddTodoPopup = new Mock<IAddTodoPopup>();
            var TodoRepository = new Mock<ITodoRepository>();
            var todo1 = new TodoItem();
            var todo2 = new TodoItem();

            TodoRepository.Setup(t => t.GetAll()).Returns(new List<TodoItem> { todo1, todo2 });

            // Act
            var result = this.GetInstance(AddTodoPopup.Object, TodoRepository.Object);

            // Assert
            Assert.AreEqual(2, result.TodoItems.Count());
            Assert.AreSame(todo1, result.TodoItems[0]);
            Assert.AreSame(todo2, result.TodoItems[1]);
        }

        [TestMethod]
        public void ShowPopup_WhenCalled_SetVisibleFlagToTrue()
        {
            // Arrange
            var result = this.GetInstance();
            result.IsAddPopupVisible = false;

            // Act
            result.ShowPopup();

            // Assert
            Assert.IsTrue(result.IsAddPopupVisible);
        }

        [TestMethod]
        public void HidePopup_WhenCalled_SetVisibleFlagToFalse()
        {
            // Arrange
            var result = this.GetInstance();
            result.IsAddPopupVisible = true;

            // Act
            result.HidePopup();

            // Assert
            Assert.IsFalse(result.IsAddPopupVisible);
            
        }

        [TestMethod]
        public void AddTodo_WhenCalled_AddTheItemToTheMainList()
        {
            // Arrange
            var result = this.GetInstance();
            var todo = new TodoItem();

            // Act
            result.AddTodo(todo);

            // Assert
            Assert.IsTrue(result.TodoItems.Contains(todo));
            Assert.AreEqual(1, result.TodoItems.Count());
        }

        [TestMethod]
        public void RemoveTodo_WhenCalled_RemoveSpecifiedItemFromTheList()
        {
            // Arrange
            var result = this.GetInstance();
            var todo1 = new TodoItem();
            var todo2 = new TodoItem();
            result.AddTodo(todo1);
            result.AddTodo(todo2);

            // Act
            result.RemoveTodo(todo2);

            // Assert
            Assert.IsTrue(result.TodoItems.Contains(todo1));
            Assert.IsFalse(result.TodoItems.Contains(todo2));
            Assert.AreEqual(1, result.TodoItems.Count());
            
        }
    }
}
