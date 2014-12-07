using Caliburn.Micro;
using TodoYouToo.Entities;
namespace TodoYouToo {
    public interface IMain {
        BindableCollection<TodoItem> TodoItems { get; }
        IAddTodoPopup AddTodoPopup { get; }
        bool IsAddPopupVisible { get; }
        void ShowPopup();
        void HidePopup();
        void AddTodo(TodoItem item);
        void SaveTodo(TodoItem item);
        void RemoveTodo(TodoItem item);
    }
}