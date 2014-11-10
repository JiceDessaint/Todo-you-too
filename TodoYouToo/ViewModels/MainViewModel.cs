using Caliburn.Micro;
using TodoYouToo.Data;
using TodoYouToo.Entities;
using System.Data.Entity;

namespace TodoYouToo {
    public class MainViewModel : PropertyChangedBase, IMain 
    {
        public BindableCollection<TodoItem> TodoItems { get; private set; }
        
        private IAddTodoPopup addTodoPopup;
        public IAddTodoPopup AddTodoPopup { 
            get { return addTodoPopup; }
            set { addTodoPopup = value; this.NotifyOfPropertyChange(() => addTodoPopup); }
        }

        private bool isAddPopupVisible = false;
        public bool IsAddPopupVisible {
            get { return isAddPopupVisible; }
            set { isAddPopupVisible = value; this.NotifyOfPropertyChange(() => isAddPopupVisible); }
        }

        private ITodoRepository todoRepository;

        public MainViewModel(IAddTodoPopup addItemPopup, ITodoRepository todoRepository)
        {
            this.AddTodoPopup = addItemPopup;
            this.AddTodoPopup.RootVM = this;
            this.todoRepository = todoRepository;
            this.TodoItems = new BindableCollection<TodoItem>();
            this.TodoItems.AddRange(todoRepository.GetAll());
        }
  
        public void ShowPopup()
        {
            this.IsAddPopupVisible = true;
        }

        public void HidePopup()
        {
            this.IsAddPopupVisible = false;
        }

        public void AddTodo(TodoItem item)
        {
            this.TodoItems.Add(item);
            this.todoRepository.Add(item);
        }

        public void RemoveTodo(TodoItem item)
        {
            this.TodoItems.Remove(item);
            this.todoRepository.Remove(item);
        }

        public void SaveTodo(TodoItem item)
        {
            this.todoRepository.SaveChanges();
        }

    }
}