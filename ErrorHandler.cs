using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class ErrorHandler
    {
        public bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public void HandleInvalidInput()
        {
            Console.WriteLine("\nInput tidak valid. Harap masukkan input yang benar.");
        }

        public void HandleBookNotFound()
        {
            Console.WriteLine("Buku tidak ditemukan, Coba Lagi !");
        }

        public bool HandleBookError(string title, string author, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || publicationYear == 0)
            {
                Console.WriteLine("\nInput tidak valid. Pastikan semua kolom diisi!");
                return false; // Jika input tidak valid, keluar dari metode.
            }
            return true;
        }
    }
}
