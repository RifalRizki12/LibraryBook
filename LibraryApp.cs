using System;

namespace LibraryBook;

class LibraryApp
{
    public static void Main(string[] args)
    {
        LibraryCatalog catalog = new LibraryCatalog();
        List<Book> books = new List<Book>();
        catalog.AddBook("Matematika", "prof. Rizki", 2013);
        catalog.AddBook("Pemograma C#", "Atoi s.comp", 2023);
        catalog.AddBook("Belajar Membaca", "Bila", 2009);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("\t MENU \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Book");
            Console.WriteLine("2. Find Book");
            Console.WriteLine("3. Exit");
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
                    if (int.TryParse(Console.ReadLine(), out int publication))
                    {
                        catalog.AddBook(title, author, publication);
                        catalog.ShowBook(books);
                    }
                    else
                    {
                        Console.WriteLine("\nInput tidak valid. Harap masukkan angka.");
                    }
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();

                    while (true)
                    {
                        Console.Clear();
                        catalog.ShowBook(books);
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("      MENU BOOK");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("1. Edit Book");
                        Console.WriteLine("2. Delete Book");
                        Console.WriteLine("3. Back");
                        Console.Write("Masukkan Pilihan : ");
                        string pilih = Console.ReadLine();

                        switch(pilih)
                        {
                            case "1":
                                Console.WriteLine("--------------------------");
                                Console.Write("Masukkan Id yang ingin di edit : ");
                                if (int.TryParse(Console.ReadLine(), out int editId))
                                {
                                    Book bookToEdit = catalog.FindBookById(editId);
                                    if (bookToEdit != null)
                                    {
                                        Console.Write("Masukkan Title Baru : ");
                                        string newTitle = Console.ReadLine();
                                        Console.Write("Masukkan Author Baru : ");
                                        string newAuthor = Console.ReadLine();
                                        Console.Write("Masukkan PublicationYear Baru : ");
                                        if (int.TryParse(Console.ReadLine(), out int newPublication))
                                        {
                                            catalog.editBook(editId, newTitle, newAuthor, newPublication);

                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid ! Masukkan tahun yang benar");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("\nID tidak ditemukan. Silakan coba lagi.");
                                    }
                                }
                                Console.ReadLine();
                                break;

                        }
                    }
            }
        }
        
    }
}