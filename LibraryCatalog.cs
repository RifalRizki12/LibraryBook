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
        List<Book> books = new List<Book>();

        public void ShowBook(List<Book> listBook)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("     Daftar Book");
            Console.WriteLine("==========================\n");

            foreach (Book book in listBook)
            {
                Console.WriteLine(
                    $"ID : {book.Id} " +
                    $"\nBook : {book.Title}" +
                    $"\nAuthor : {book.Author}" +
                    $"\nPublication Year : {book.PublicationYear}\n");
            }
        }
        public void AddBook(string addTitle, string addAuthor, int addPublication)
        {
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

            Book newBook = new Book(nextId, addTitle, addAuthor, addPublication);
            books.Add(newBook);
            Console.WriteLine("Data Buku berhasil ditambah !!!\n");
        }

        public Book FindBookById(int id)
        {
            return books.FirstOrDefault(u => u.Id == id);
        }

        public void editBook(int id, string newTitle, string newAuthor, int newPublication)
        {
            Book bookEdit = FindBookById(id);

            bookEdit.Title = newTitle;
            bookEdit.Author = newAuthor;
            bookEdit.PublicationYear = newPublication;

            Console.WriteLine($"\nData book dengan ID {id} telah diubah !\n");
        }

        public void deleteBook(int id)
        {
            Book bookDelete = FindBookById(id);
            if (bookDelete != null)
            {
                books.Remove(bookDelete);
                Console.WriteLine($"Data dengan id {id} berhasil dihapus ! \n");
            }
            else
            {
                Console.WriteLine($"Data dengan id {id} tidak ada !");
            }
        }

        public void searchBook(string book)
        {
            var searchUser = books.Where(u => Regex.IsMatch(u.Title, book, RegexOptions.IgnoreCase) ||
                                          Regex.IsMatch(u.Author, book, RegexOptions.IgnoreCase)).ToList();

            if (searchUser.Count == 0)
            {
                Console.WriteLine("Tidak ada book yang cocok dengan kata kunci yang diberikan !");
            }
            else
            {
                ShowBook(searchUser);
            }
        }

    }
}
