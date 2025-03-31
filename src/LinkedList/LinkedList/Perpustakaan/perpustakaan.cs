using System;

namespace LinkedList.perpustakaan
{
    public class buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public buku Buku { get; set; }
        public BukuNode Next { get; set; }
        public BukuNode(buku buku)
        {
            Buku = buku;
            Next = null;
        }
    }
    
    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public void TambahBuku(buku buku)
        {
            BukuNode newNode = new BukuNode(buku);
            newNode.Next = head;
            head = newNode;
        }
        public bool HapusBuku (string judul)
        {
            BukuNode current = head;
            BukuNode previous = null;

            while(current.Buku.Judul.Equals(judul, StringComparison.OrdinalIgnoreCase))
            {
                if(previous == null)
                    head = current.Next; //klo head yng dihapus
                else
                {
                    previous.Next = current.Next; //lwating node yng dihapus
                    return true;
                }
                previous = current;
                current = current.Next;
                }
            return false; //klo buku tdk ditemukan
        }
        public buku[] CariBuku(string kataKunci)
        {
            List<buku> hasil = new List<buku>();
            BukuNode current = head;

            while(current != null)
            {
                if (current.Buku.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    hasil.Add(current.Buku);
                }
                current = current.Next;
            }
            return hasil.ToArray();
        }

        public void TampilKoleksi()
        {
            BukuNode current = head;
            while (current != null)
            {
                Console.WriteLine($"\"{current.Buku.Judul}\"; {current.Buku.Penulis}; {current.Buku.Tahun}");
                current = current.Next;
            }
        }
    }
}