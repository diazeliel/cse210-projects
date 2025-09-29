using System;

public class Comment
{
    // Private Fields (Encapsulation)
    private readonly string _commenterName;
    private readonly string _commentText;

    // Public Read-Only Properties (Abstraction/Getters)
    public string CommenterName => _commenterName;
    public string CommentText => _commentText;

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }
}