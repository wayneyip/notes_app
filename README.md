# Notes App

**Author**: Yip Wen Qian (Wayne)

**Technologies**: C#, .NET

## Description

A note-taking application on the command line. Write something!

![image](https://github.com/user-attachments/assets/baacbb60-f663-4a8b-96d6-27770d230610)

## Features

**Create Note**

Create a note with a title and some content.

https://github.com/user-attachments/assets/23b7a940-21b5-4db1-97f3-cbef2ae5bca5

**View Notes**

Select and view a note from your list of notes. 

https://github.com/user-attachments/assets/9d0291e1-151a-4124-8a30-ab6be224c0ce

**Delete Note**

Select and delete a note from your list of notes. 

https://github.com/user-attachments/assets/6ea57ab5-e362-4651-81fc-48f937415af1

## Setup Instructions

**Requirements**
- This application requires [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), the latest .NET SDK on Long Term Support.

**Steps**
1. Clone this repository to your machine.
2. In a terminal, navigate to the location of your cloned repository.
3. Enter `dotnet run` to run the application.
4. Enjoy!

## Testing
 I accounted for the following test cases at each stage of the application:
 
**Main Menu**
- Rejects any input outside of the listed index numbers
    
**View Notes / Delete Note**:
- Rejects negative numbers
- Rejects numbers higher than the existing number of notes
- Rejects non-numerical strings

## Additional Dev Notes

**Separation of Concerns**:
- I decoupled the logic of frontend and backend for cleanliness, making it easier to scale the app later with a full graphical interface or more complex functionality.
- **NotesApp.cs** deals with frontend I/O logic.
- **NotesData.cs** manages the backend data on notes.
- **Note.cs** encapsulates the data for a single note (i.e. title and content).
- **IOUtils.cs** provides app-agnostic helper functions for I/O purposes.

**Scalability**: 
- In respect of the Don't Repeat Yourself principle, I used an action delegate for features that have similar I/O behaviour but run different functions (View Notes and Delete Note).
- This helps to simplify the future implementation of similar features, e.g. Edit Note. 
