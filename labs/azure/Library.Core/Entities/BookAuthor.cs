using System;

namespace Library.Core.Entities
{
    public class BookAuthor : Entity
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}