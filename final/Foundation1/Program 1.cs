using System;
using System.Collections.Generic;

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comments.Add(new Comment(commenter, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (seconds): {Length}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"{comment.Commenter}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        var videos = new List<Video>();

        var video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment("User 1", "Great video!");
        video1.AddComment("User 2", "I learned a lot.");
        videos.Add(video1);

        var video2 = new Video("Video 2", "Author 2", 450);
        video2.AddComment("User 3", "Interesting topic.");
        videos.Add(video2);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}