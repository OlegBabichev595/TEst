using System;

namespace NET01._1.Entities
{
    public class TextMaterial : TrainingMaterial
    {
        private const int DescriptionMaterialLength = 10000;
        private string _descriptionMaterial;

        public TextMaterial(string description, string descriptionMaterial)
            : base(description)
        {
            DescriptionMaterial = descriptionMaterial;
        }

        public string DescriptionMaterial
        {
            get => _descriptionMaterial;

            set
            {
                CheckForNullString(value);
                if (value.Length > DescriptionMaterialLength)
                {
                    throw new Exception($"The Text material should be less then {DescriptionMaterialLength} symbols!!!!!!");
                }

                _descriptionMaterial = value;
            }
        }

        public override string ToString()
        {
            return $"Text material description - {Description}";
        }
    }
}