using System.Collections.Generic;
using Library.Core.Entities;

namespace Library.Web.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
        public string PublisherId { get; set; }
    }
}