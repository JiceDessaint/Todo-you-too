using System;
namespace TodoYouToo {
    public interface IAddTodoPopup {
        IMain RootVM { get; set; }

        string Text { get; set; }

        DateTime Date { get; set; }

        void Add();

    }
}