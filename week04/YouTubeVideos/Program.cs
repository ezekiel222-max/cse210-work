using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        var video1 = new Video("Tech Review", "Alice", 300);
        video1.AddComment(new Comment("John", "Great review!"));
        video1.AddComment(new Comment("Emma", "Thanks for the info."));
        video1.AddComment(new Comment("Mike", "Super helpful."));
        videos.Add(video1);

        var video2 = new Video("Cooking Pasta", "Chef Lora", 600);
        video2.AddComment(new Comment("Sally", "Looks delicious!"));
        video2.AddComment(new Comment("Tom", "I’ll try this tonight."));
        video2.AddComment(new Comment("Anna", "Easy to follow!"));
        videos.Add(video2);

        var video3 = new Video("Travel Vlog", "Wanderer", 480);
        video3.AddComment(new Comment("Liam", "Where is this place?"));
        video3.AddComment(new Comment("Sophia", "Gorgeous views!"));
        video3.AddComment(new Comment("Noah", "Added to my bucket list."));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
