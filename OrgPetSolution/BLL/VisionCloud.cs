using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class VisionCloud
    {

        public static List<string> VerificarImagem(byte[] imagem)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", HttpContext.Current.Server.MapPath(@"~/App_Data/CloudVisionConfig.json"));
            // Instantiates a client    
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Google.Cloud.Vision.V1.Image.FromBytes(imagem);
            var responseLbl = client.DetectLabels(image);
            var responseProp = client.DetectImageProperties(image);

            List<EntityAnnotation> animals = responseLbl.Take(8).ToList();
            for (int i = 0; i < animals.Count; i++)
            {
                if (string.Compare(animals[i].Description, "dog", true) == 0 ||
                   string.Compare(animals[i].Description, "black", true) == 0 ||
                   string.Compare(animals[i].Description, "brown", true) == 0 ||
                   string.Compare(animals[i].Description, "carnivore", true) == 0 ||
                   string.Compare(animals[i].Description, "canidae", true) == 0 ||
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
            List<string> descricoes = animals.ConvertAll<string>(c => c.Description);
            return descricoes;
        }
    }
}
