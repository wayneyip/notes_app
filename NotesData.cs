using System;

public class NotesData
{
    private List<Note> notes = new List<Note>();

    public void AddNote(string title, string content)
    {
        Note newNote = new(title, content);
        notes.Add(newNote);
    }

    public int GetNotesCount()
    { 
        return notes.Count; 
    }

    public List<string> GetNoteTitles()
    {
        List<string> titles = new List<string>();

        foreach (Note note in notes)
        {
            titles.Add(note.Title);
        }

        return titles;
    }

    public string GetTitleAt(int index)
    {
        return notes[index].Title;
    }

    public string GetContentAt(int index) 
    {  
        return notes[index].Content; 
    }

    public void RemoveNoteAt(int index) 
    {
        notes.RemoveAt(index);
    }
}
