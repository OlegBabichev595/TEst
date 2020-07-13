using System;

namespace NET01._1.Entities
{
    public abstract class Entity
    {
        private string _description;
        private const int DescriptionLength = 256;
        protected Entity(string description)
        {
            Description = CheackStringForNull(description);
        }

        public string Description
        {
            get => _description;
            set => _description = CheackStringForNull(value);
        }

        public Guid Guid { get; set; }

        public override string ToString()
        {
            return _description;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity);
        }


        public bool Equals(Entity other)
        {
            return other != null && GetHashCode() == other.GetHashCode();
        }


        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        private string CheackStringForNull(string value)
        {
            if (value == null)
            {
                return null;
            }

            if (value.Length > DescriptionLength)
            {
                throw new Exception($"Should be less then {DescriptionLength}!!!!");
            }

            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }
}