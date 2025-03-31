using System;
using LinkedList.perpustakaan;
using LinkedList.ManajemenKaryawan;
using LinkedList.Inventori;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        KoleksiPerpustakaan koleksiPerpustakaan = new KoleksiPerpustakaan();
        koleksiPerpustakaan.TambahBuku(new buku("The Hobbit", "J.R.R Tolkien", 1937));
        koleksiPerpustakaan.TambahBuku(new buku("1984", "George Orwell", 1949));
        koleksiPerpustakaan.TambahBuku(new buku("The Catcher in the Rye", "J.D. Salinger", 1951));

        Console.WriteLine();
        koleksiPerpustakaan.TampilKoleksi();



        // Soal ManajemenKaryawan
        DaftarKaryawan daftarKaryawan = new DaftarKaryawan();
        daftarKaryawan.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftarKaryawan.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
        daftarKaryawan.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));

        Console.WriteLine();
        daftarKaryawan.TampilDaftarKaryawan();



        // Soal Inventori
        ManajemenInventori manajemenInventori = new ManajemenInventori();
        // Menambahkan beberapa item
        manajemenInventori.TambahItem(new item("Apple", 50));
        manajemenInventori.TambahItem(new item("Orange", 30));
        manajemenInventori.TambahItem(new item("Banana", 20));

        Console.WriteLine("Nama item; Kuantitas");
        manajemenInventori.TampilkanInventori();

    }
}
