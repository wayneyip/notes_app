# Notes App

**Author**: Yip Wen Qian (Wayne)

**Technologies**: C#, .NET

## Project Description


## Instructions



## Development Notes

**Separation of Concerns**:
- I decoupled the logic of frontend and backend for cleanliness, making it easier to scale the app later with a full graphical interface or more complex functionality.
- **NotesApp.cs** deals with frontend I/O logic.
- **NotesData.cs** manages the backend data on notes.
- **Note.cs** encapsulates the data for a single note (i.e. title and content).
- **IOUtils.cs** provides app-agnostic helper functions for I/O purposes.

**Scalability**: 
- In respect of the Don't Repeat Yourself principle, I used an action delegate for features that have similar I/O behaviour but run different functions (View Notes and Delete Note).
- This helps to simplify the future implementation of similar features, e.g. Edit Note. 
