using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoYouToo.Entities;
using TodoYouToo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Tests.ViewModels
{
    [TestClass]
    public class AddTodoPopupViewModelTest
    {
        private AddTodoPopupViewModel GetInstance()
        {
            return new AddTodoPopupViewModel(new Mock<IDateTimeProvider>().Object);
        }

        private AddTodoPopupViewModel GetInstance(IDateTimeProvider dateTimeProvider)
        {
            return new AddTodoPopupViewModel(dateTimeProvider);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ShouldSetInitialDate()
        {
            // Arrange
            var dtProvider = new Mock<IDateTimeProvider>();
            var actualDate = new DateTime(2000, 01, 01);
            dtProvider.SetupGet(d => d.Now).Returns(actualDate);
            var expectedDate = new DateTime(2000, 01, 02);
            // Act
            var result = this.GetInstance(dtProvider.Object);

            // Assert
            Assert.AreEqual(expectedDate, result.Date);
        }

        [TestMethod]
        public void Cancel_And_ResetAndClose_WhenCalled_ShouldResetAndHideViewModel()
        {
            // Arrange
            var dtProvider = new Mock<IDateTimeProvider>();
            var actualDate = new DateTime(2000, 01, 01);
            var expectedDate = new DateTime(2000, 01, 02);
            dtProvider.SetupGet(d => d.Now).Returns(actualDate);

            var rootVM = new Mock<IMain>();

            var result = this.GetInstance(dtProvider.Object);
            result.RootVM = rootVM.Object;
            result.Text = "blabla";
            result.Date = new DateTime(2014, 03, 23);

            // Act
            result.Cancel();
            
            // Assert
            Assert.AreEqual(expectedDate, result.Date);
            Assert.IsTrue(string.IsNullOrEmpty(result.Text));
            rootVM.Verify(root => root.HidePopup(), Times.Once());
            rootVM.Verify(root => root.AddTodo(It.IsAny<TodoItem>()), Times.Never());
        }

        [TestMethod]
        public void Add_WhenCalled_ShouldSaveTodoAndResetVM()
        {
            // Arrange
            var dtProvider = new Mock<IDateTimeProvider>();
            var actualDate = new DateTime(2000, 01, 01);
            var expectedDate = new DateTime(2000, 01, 02);
            dtProvider.SetupGet(d => d.Now).Returns(actualDate);
            string text = "Become the master of the Internet";
            var rootVM = new Mock<IMain>();
            rootVM.Setup(root => root.AddTodo(It.IsAny<TodoItem>())).Callback<TodoItem>(item =>
            {
                Assert.AreEqual(text, item.Text);
                Assert.AreEqual(expectedDate, item.DueDate);
                Assert.IsFalse(item.IsDone);
            });

            var result = this.GetInstance(dtProvider.Object);
            result.RootVM = rootVM.Object;
            result.Text = text;
            result.Date = expectedDate;

            // Act
            result.Add();
            
            // Assert
            Assert.AreEqual(expectedDate, result.Date);
            Assert.IsTrue(string.IsNullOrEmpty(result.Text));
            rootVM.Verify(root => root.HidePopup(), Times.Once());
            rootVM.Verify(root => root.AddTodo(It.IsAny<TodoItem>()), Times.Once());
        }

        [TestMethod]
        public void CanAdd_WhenStringEmpty_ShouldReturnFalse()
        {
            // Arrange
            var vm = this.GetInstance();
            vm.Text = string.Empty;

            // Act
            var result = vm.CanAdd;

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CanAdd_WhenStringNotEmpty_ShouldReturnTrue()
        {
            // Arrange
            var vm = this.GetInstance();
            vm.Text = "A";

            // Act
            var result = vm.CanAdd;

            // Assert
            Assert.IsTrue(result);
        }



    }
}
