using System;

namespace NET01._1.Entities
{
    public abstract class TrainingMaterial : Entity
    {
        protected TrainingMaterial(string description)
            : base(description)
        {
        }

        public override string ToString()
        {
            return $"Training material description - {Description}";
        }


        protected bool CheckForNullString(string param)
        {
            if (string.IsNullOrWhiteSpace(param) || string.IsNullOrEmpty(param))
            {
                throw new NullReferenceException("The string can't be empty!!!!!!");
            }

            return true;
        }
    }
}