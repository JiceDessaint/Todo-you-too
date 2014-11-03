namespace TodoYouToo {
    public interface IAddTodoPopup {
        IMain RootVM { get; set; }

        string Text { get; set; }

        void Add();

    }
}