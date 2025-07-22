using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create video list
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video("Learning C# in 15 Minutes", "Tech Guru", 900);
        video1.AddComment(new Comment("Alice", "This was super helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Clear explanation, appreciate it."));
        video1.AddComment(new Comment("Charlie", "Great for beginners."));
        videos.Add(video1);

        // Second video
        Video video2 = new Video("Top 10 Productivity Tools", "LifeHackPro", 660);
        video2.AddComment(new Comment("Dana", "I use 3 of these already!"));
        video2.AddComment(new Comment("Eli", "Adding #7 to my workflow now."));
        video2.AddComment(new Comment("Fran", "Love the quick breakdown."));
        videos.Add(video2);

        // Third video
        Video video3 = new Video("History of the Internet", "InfoTime", 1200);
        video3.AddComment(new Comment("Gina", "Mind blown! Never knew this."));
        video3.AddComment(new Comment("Hank", "So well put together."));
        video3.AddComment(new Comment("Ivy", "Shared this with my class."));
        videos.Add(video3);

        // Fourth video
        Video video4 = new Video("Daily Stretching Routine", "FlexFit", 480);
        video4.AddComment(new Comment("Jake", "Feeling great already."));
        video4.AddComment(new Comment("Kara", "Love the instructor’s energy!"));
        video4.AddComment(new Comment("Leo", "Adding this to my mornings."));
        videos.Add(video4);

        // Display all videos
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}

// =========================
// Video Class
// =========================
class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (Comment c in _comments)
        {
            c.DisplayComment();
        }
    }
}

// =========================
// Comment Class
// =========================
class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"- {_commenterName}: {_text}");
    }
}
