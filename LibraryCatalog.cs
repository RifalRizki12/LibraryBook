using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class LibraryCatalog
    {
        static List<Book> books = new List<Book>();
        ErrorHandler errorHandler = new ErrorHandler();
        public static LibraryCatalog catalog = new LibraryCatalog();

        public void ShowSearchBook(Book book)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("     Daftar Book");
            Console.WriteLine("==========================\n");

            Console.WriteLine($"ID : {book.Id}");
            Console.WriteLine($"Judul : {book.Title}");
            Console.WriteLine($"Penulis : {book.Author}");
            Console.WriteLine($"Tahun Terbit : {book.PublicationYear}\n");
        }

        public void ShowAllBook()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("     Daftar Buku");
            Console.WriteLine("==========================\n");

            foreach (Book book in books)
            {
                Console.WriteLine($"ID : {book.Id}");
                Console.WriteLine($"Judul : {book.Title}");
                Console.WriteLine($"Penulis : {book.Author}");
                Console.WriteLine($"Tahun Terbit : {book.PublicationYear}\n");
            }
        }

        public void AddBook(Book book)
        {
            if (!errorHandler.HandleBookError(book.Title, book.Author, book.PublicationYear))
            {
                // Input tidak valid, keluar dari metode
                return;
            }
            int nextId = 1; // Menentukan ID berikutnya
            if (books.Count > 0)
            {
                nextId = books.Max(x => x.Id) + 1;
            }
            // Mengecek apakah setiap ID sudah ada dalam daftar pengguna
            while (books.Any(u => u.Id == nextId))
            {
                nextId++;
            }

            book.Id = nextId; // Set ID buku sesuai dengan yang dihitung
            books.Add(book);
            Console.WriteLine("\nData Buku berhasil ditambah !!!");
        }

        public Book FindBookById(int id)
        {
            return books.FirstOrDefault(u => u.Id == id);
        }

        public Book FindBook(string title)
        {
            return books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void editBook(int id, string newTitle, string newAuthor, int newPublication)
        {
            if (!errorHandler.HandleBookError(newTitle, newAuthor, newPublication))
            {
                // Input tidak valid, keluar dari metode
                return;
            }

            Book bookEdit = FindBookById(id);

            bookEdit.Title = newTitle;
            bookEdit.Author = newAuthor;
            bookEdit.PublicationYear = newPublication;

            Console.WriteLine($"\nData book dengan ID {id} telah diubah !\n");
        }

        public void deleteBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                Console.WriteLine($"Data dengan ID {book.Id} berhasil dihapus!\n");
            }
            else
            {
                Console.WriteLine($"Data dengan ID {book.Id} tidak ada!");
            }
        }

        /*public void searchBook(string title)
        {
            var searchUser = books.Where(u => Regex.IsMatch(u.Title, title, RegexOptions.IgnoreCase) ||
                                          Regex.IsMatch(u.Author, title, RegexOptions.IgnoreCase)).ToList();

            if (searchUser.Count == 0)
            {
                errorHandler.HandleSearchNotFound();
            }
            else
            {
                ShowBook(searchUser);
            }
        }*/

    }
}
