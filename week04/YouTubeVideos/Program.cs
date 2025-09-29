using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create a list to hold the videos
        List<Video> videoList = new List<Video>();

        // --- Video 1: Programming Tutorial ---
        Video video1 = new Video("C# Basics, abstraction", "Dev Master", 1200);
        video1.AddComment(new Comment("User101", "Great explanation of C# properties!"));
        video1.AddComment(new Comment("CodeGeek", "Very clear and concise. Thanks!"));
        video1.AddComment(new Comment("TechNovice", "I finally understand abstraction."));
        videoList.Add(video1);

        // --- Video 2: Travel Vlog ---
        Video video2 = new Video("Nature", "Wanderlust Life", 985);
        video2.AddComment(new Comment("TravelFan", "The views are incredible!"));
        video2.AddComment(new Comment("NatureLover", "What kind of camera do you use?"));
        video2.AddComment(new Comment("MountainMan", "I wish I could go here!"));
        video2.AddComment(new Comment("AdventureSeeker", "Any tips for beginners?"));
        videoList.Add(video2);

        // --- Video 3: Cooking Demo ---
        Video video3 = new Video("30 Minute Pasta Carbonara Recipe", "Chef Antoine", 450);
        video3.AddComment(new Comment("FoodieGuru", "The best carbonara recipe I've tried."));
        video3.AddComment(new Comment("HomeCook", "Used pancetta instead of guanciale—still amazing!"));
        video3.AddComment(new Comment("BusyMom", "Quick and delicious. A lifesaver!"));
        videoList.Add(video3);

        // 2. Iterate through the list and display information
        Console.WriteLine("==================================================");
        Console.WriteLine("         YouTube Video Tracker Report");
        Console.WriteLine("==================================================");

        foreach (Video video in videoList)
        {
            Console.WriteLine($"\n--- Video: {video.Title} ---");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            // Call the method to demonstrate abstraction/behavior
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}"); 
            Console.WriteLine("----------------------------------");
            
            // List all comments
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  [{comment.CommenterName}]: {comment.CommentText}");
            }
            Console.WriteLine("==================================================");
        }
    }
}