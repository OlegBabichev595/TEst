using System;
using NET01._1.Entities;
using NET01._1.FormatEnums;

namespace NET01._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var train1 = new TrainingSession(null, new byte[8]);
            Console.WriteLine(train1);
            var video = new VideoMaterial("sdas", VideoFormat.Mp4, "sadasdasda", new byte[8]);
            var textMaterial = new TextMaterial("asdas", "12");
            textMaterial.DescriptionMaterial = "asdasd";
            Console.WriteLine(textMaterial);
            train1.Guid = train1.GenerateGuid();
            train1.AddMaterial(textMaterial);
            var train2 = (TrainingSession) train1.Clone();
            train1.AddMaterial(video);
            Console.WriteLine(train1.GetTrainingMaterial());
            Console.WriteLine(train2.GetTrainingMaterial());
        }
    }
}