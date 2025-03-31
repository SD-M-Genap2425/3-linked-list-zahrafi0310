using System;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode prev { get; set; }
        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            prev = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        //nambah karyawan
        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
        }

        //hapus karyawan
        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode current = head;
            while (current != null)
            {
                if (current.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (current.prev != null)
                        current.prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.prev = current.prev;
                    else
                        tail = current.prev;

                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //cari karyawan
        public List<Karyawan> CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode current = head;
            while (current != null)
            {
                if (current.Karyawan.Nama.Contains(kataKunci) || current.Karyawan.Posisi.Contains(kataKunci))
                {
                    hasil.Add(current.Karyawan);
                }
                current = current.Next;
            }
            return hasil;
        }

        public void TampilDaftarKaryawan()
        {
            KaryawanNode current = tail;
            while (current != null)
            {
                Console.WriteLine($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
                current = current.prev;
            }
        }
    }
}
