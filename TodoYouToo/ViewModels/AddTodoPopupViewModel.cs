using Caliburn.Micro;
using TodoYouToo.Entities;
using TodoYouToo.Interfaces;
using System;

namespace TodoYouToo {
    public class AddTodoPopupViewModel : PropertyChangedBase, IAddTodoPopup 
    {
        private IDateTimeProvider dateTimeProvider;

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; this.NotifyOfPropertyChange(() => Date); }
        }
        
        private string text;
        public string Text {
            get { return text; }
            set 
            { 
                text = value; 
                this.NotifyOfPropertyChange(() => Text);
                this.NotifyOfPropertyChange(() => CanAdd);
            }
        }

        public IMain RootVM { get; set; }

        public AddTodoPopupViewModel(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.Date = GetInitialDate();
        }

        private DateTime GetInitialDate()
        {
            return this.dateTimeProvider.Now.AddDays(1);
        }

        private void ResetAndClose()
        {
            this.Date = GetInitialDate();
            this.Text = string.Empty;
            this.RootVM.HidePopup();
        }
        public void Add()
        {
            this.RootVM.AddTodo(new TodoItem { Text = this.Text, IsDone = false, DueDate = this.Date });
            this.ResetAndClose();
        }
        public bool CanAdd
        {
            get { return !string.IsNullOrWhiteSpace(Text); }
        }

        public void Cancel()
        {
            this.ResetAndClose();
        }

    }
}