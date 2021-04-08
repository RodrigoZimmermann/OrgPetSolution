using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\moc\Downloads\My First Project-ad852ad14d77.json");
            // Instantiates a client    
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Google.Cloud.Vision.V1.Image.FromFile(@"C:\Users\moc\Desktop\Cachorros\Bull terrier.jfif");             // Performs label detection on the image file
            var responseLbl = client.DetectLabels(image);
            var responseProp = client.DetectImageProperties(image);

            List<EntityAnnotation> animals = responseLbl.Take(10).ToList();
            for (int i = 0; i < animals.Count; i++)
            {
                if(string.Compare(animals[i].Description,"dog",true) == 0 ||
                   string.Compare(animals[i].Description, "black", true) == 0 ||
                   string.Compare(animals[i].Description, "brown", true) == 0 ||
                   string.Compare(animals[i].Description, "carnivore", true) == 0 ||
                   string.Compare(animals[i].Description, "canidae", true) == 0  ||
                   string.Compare(animals[i].Description, "mammal", true) == 0 ||
                   string.Compare(animals[i].Description, "vertebrate", true) == 0 ||
                   string.Compare(animals[i].Description, "dog breed", true) == 0 ||
                   string.Compare(animals[i].Description, "dog breed", true) == 0 ||
                   string.Compare(animals[i].Description, "bear", true) == 0 ||
                   string.Compare(animals[i].Description, "wolf", true) == 0 ||
                   string.Compare(animals[i].Description, "guard dog", true) == 0 ||
                   string.Compare(animals[i].Description, "companion dog", true) == 0 ||
                   string.Compare(animals[i].Description, "hunting dog", true) == 0 ||
                   string.Compare(animals[i].Description, "fawn", true) == 0 ||
                   string.Compare(animals[i].Description, "snout", true) == 0 ||
                   string.Compare(animals[i].Description, "sporting group", true) == 0 ||
                   string.Compare(animals[i].Description, "wolf", true) == 0 ||
                   string.Compare(animals[i].Description, "giant dog breed", true) == 0 ||
                   string.Compare(animals[i].Description, "molosser ", true) == 0 ||
                   string.Compare(animals[i].Description, "working dog ", true) == 0 ||
                   string.Compare(animals[i].Description, "muscle", true) == 0 ||
                   string.Compare(animals[i].Description, "sporting group", true) == 0 ||
                   string.Compare(animals[i].Description, "toy dog", true) == 0 ||
                   string.Compare(animals[i].Description, "rare breed (dog)", true) == 0 ||
                   string.Compare(animals[i].Description, "russkiy dog", true) == 0
                   )
                {
                    animals.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine();
            int count = 0;
            foreach (var color in responseProp.DominantColors.Colors)
            {
                Color cr = Color.FromArgb((int)color.Color.Red, (int)color.Color.Green, (int)color.Color.Blue);
                Bitmap bmp = new Bitmap(200, 200);

                for (int i = 0; i < 200; i++)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        bmp.SetPixel(i, j, cr);
                    }
                }
                bmp.Save("teste"+count+".jpg");
                count++;
                Console.ReadLine();
            }
        }
    }
}

