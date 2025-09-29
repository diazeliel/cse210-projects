using System.Collections.Generic;

public class Video
{
    // Private Fields (Encapsulation)
    private readonly string _title;
    private readonly string _author;
    private readonly int _lengthSeconds;
    private readonly List<Comment> _comments = new List<Comment>();

    // Public Read-Only Properties (Abstraction/Getters)
    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    // Expose comments as a read-only list to prevent outside code from directly altering the collection.
    public IReadOnlyList<Comment> Comments => _comments; 

    // Constructor
    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    // Method to add a comment (Controlled access)
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments (Abstraction/Behavior)
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}