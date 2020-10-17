using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Author : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }

        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}