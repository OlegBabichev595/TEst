using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Library.Core.Entities
{
    public sealed class Book : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishingDate { get; set; }
        public float? Rating { get; set; }
        public string CoverUrl { get; set; }

        public Guid? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }

        public Book()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public string GetPublishingDateString() =>
            PublishingDate.HasValue ? PublishingDate.Value.ToShortDateString() : string.Empty;

        public string GetRatingString() =>
            Rating.HasValue ? Rating.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;

        public string GetAuthorsString() => BookAuthor.Count > 0
            ? string.Join(", ", BookAuthor.Select(x => x.Author.ToString()))
            : string.Empty;
    }
}