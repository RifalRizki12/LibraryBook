using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class Book
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book() { }
        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
    }
}
