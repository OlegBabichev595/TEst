using System;
using NET01._1.FormatEnums;

namespace NET01._1.Entities
{
    public class LinkResourse : TrainingMaterial
    {
        private string _content;
        private LinkType _linkType;

        public LinkResourse(string description, LinkType linkType, string content)
            : base(description)
        {
            LinkType = linkType;
            Content = content;
        }

        public string Content
        {
            get => _content;

            set
            {
                CheckForNullString(value);
                _content = value;
            }
        }

        public LinkType LinkType
        {
            get => _linkType;
            set
            {
                CheckEnumValue(value, nameof(value));
                _linkType = value;
            }
        }

        private void CheckEnumValue<TEnum>(TEnum value, string paramName) where TEnum : Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public override string ToString()
        {
            return $"Link Resourses description - {Description}";
        }
    }
}