using System;
using System.Diagnostics.Contracts;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 100)
        {
            throw new ArgumentException("Judul video harus memiliki panjang maksimal 100 karakter dan tidak null");
        }

        this.id = new Random().Next(10000, 99999); 
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentException("Penambahan play count harus di antara 0 dan 10.000.000");
        }
            checked
            {
                this.playCount += count;
            }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Rizki Muhammad Ridwan");
        try
        {
            video.IncreasePlayCount(20000000); 
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); 
        }

        try
        {
            for (int i = 0; i < 1000000000; i++) 
            {
                video.IncreasePlayCount(1); 
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message); 
        }

        video.PrintVideoDetails();
    }
}