public class Note
{
    private string noteTitle;
    private string noteContent;

    public Note(string title, string content)
    {
        noteTitle = title;
        noteContent = content;
    }

    public string Title
    {
        get => noteTitle;
        set => noteTitle = value;
    }

    public string Content
    {
        get => noteContent;
        set => noteContent = value;
    }
}