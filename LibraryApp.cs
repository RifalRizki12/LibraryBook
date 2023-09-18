using System;

namespace LibraryBook;

class LibraryApp
{
    public static void Main(string[] args)
    {
        LibraryCatalog catalog = new LibraryCatalog();
        ErrorHandler errorHandler = new ErrorHandler();
        //Data Dummy
        catalog.AddBook("Matematika", "prof. Rizki", 2013);
        catalog.AddBook("Pemograma C#", "Atoi s.comp", 2023);
        catalog.AddBook("Belajar Membaca", "Bila", 2009);

        string book;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("\t MENU \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Book");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("      ADD BOOK");
                    Console.WriteLine("--------------------------"); ;
                    Console.Write("Enter Title Book : ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author : ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Publication : ");
                    book = Console.ReadLine();
                    if (errorHandler.TryParseInt(book, out int publication))
                    {
                        catalog.AddBook(title, author, publication);
                    }
                    else
                    {
                        errorHandler.HandleInvalidInput();
                    }
                    Console.Write("Tekan Enter untuk kembali !!! ");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    catalog.ListBook();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("      MENU BOOK");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1. Edit Book");
                    Console.WriteLine("2. Delete Book");
                    Console.WriteLine("3. Back");
                    Console.Write("Masukkan Pilihan : ");
                    string pilih = Console.ReadLine();

                    switch (pilih)
                    {
                        case "1":
                            Console.WriteLine("--------------------------");
                            Console.Write("Masukkan Id yang ingin di edit : ");
                            book = Console.ReadLine();
                            if (errorHandler.TryParseInt(book, out int editId))
                            {
                                Book bookToEdit = catalog.FindBookById(editId);
                                if (bookToEdit != null)
                                {
                                    Console.Write("Masukkan Title Baru : ");
                                    string newTitle = Console.ReadLine();
                                    Console.Write("Masukkan Author Baru : ");
                                    string newAuthor = Console.ReadLine();
                                    Console.Write("Masukkan PublicationYear Baru : ");
                                    book = Console.ReadLine();
                                    if (errorHandler.TryParseInt(book, out int newPublication))
                                    {
                                        catalog.editBook(editId, newTitle, newAuthor, newPublication);

                                    }
                                    else
                                    {
                                        errorHandler.HandleInvalidInput();
                                    }
                                }
                                else
                                {
                                    errorHandler.HandleBookNotFound();
                                }
                            }
                            else
                            {
                                errorHandler.HandleInvalidInput();
                            }
                            Console.Write("Tekan Enter Untuk Kembali !!!");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("--------------------------");
                            Console.Write("Masukkan Id Book yang ingin di hapus : ");
                            book = Console.ReadLine();
                            if (errorHandler.TryParseInt(book, out int deleteId))
                            {
                                catalog.deleteBook(deleteId);
                            }
                            else
                            {
                                errorHandler.HandleInvalidInput();
                            }
                            Console.Write("Tekan Enter Untuk Kembali !!!");
                            Console.ReadLine();
                            break;

                        case "3":
                            break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Masukkan Title/Author Book yang ingin dicari : ");
                    string searchName = Console.ReadLine();
                    if (searchName != "")
                    {
                        catalog.searchBook(searchName);
                    }
                    else
                    {
                        errorHandler.HandleBookNotFound();
                    }
                    Console.Write("Tekan Enter Untuk Kembali !!!");
                    Console.ReadLine();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            }
        }
        
    }
}