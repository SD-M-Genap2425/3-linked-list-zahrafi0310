using System;

namespace LinkedList.Inventori
{
    public class item
    {
        public string Nama { get; set; }
        public int Kuantitas { get; set; }

        public item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    public class ManajemenInventori
    {
        private LinkedList<item> inventori = new LinkedList<item>();

        //nambah item
        public void TambahItem(item item)
        {
            inventori.AddLast(item);
        }

        //hapus item berdasarkan nama
        public bool HapusItem(string nama)
        {
            var current = inventori.First;
            while (current != null)
            {
                if (current.Value.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
                {
                    inventori.Remove(current);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //tampilkan semua item
        public void TampilkanInventori()
        {
            foreach (var item in inventori)
            {
                Console.WriteLine($"Nama: {item.Nama}, Kuantitas: {item.Kuantitas}");
            }
        }
    }
}
