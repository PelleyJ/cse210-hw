using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# in 15 Minutes", "Tech Guru", 900);
        video1.AddComment(new Comment("Alice", "This was super helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Clear explanation, appreciate it."));
        video1.AddComment(new Comment("Charlie", "Great for beginners."));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Productivity Tools", "LifeHackPro", 660);
        video2.AddComment(new Comment("Dana", "I use 3 of these already!"));
        video2.AddComment(new Comment("Eli", "Adding #7 to my workflow now."));
        video2.AddComment(new Comment("Fran", "Love the quick breakdown."));
        videos.Add(video2);

        Video video3 = new Video("History of the Internet", "InfoTime", 1200);
        video3.AddComment(new Comment("Gina", "Mind blown! Never knew this."));
        video3.AddComment(new Comment("Hank", "So well put together."));
        video3.AddComment(new Comment("Ivy", "Shared this with my class."));
        videos.Add(video3);

        Video video4 = new Video("Daily Stretching Routine", "FlexFit", 480);
        video4.AddComment(new Comment("Jake", "Feeling great already."));
        video4.AddComment(new Comment("Kara", "Love the instructor’s energy!"));
        video4.AddComment(new Comment("Leo", "Adding this to my mornings."));
        videos.Add(video4);

        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}
