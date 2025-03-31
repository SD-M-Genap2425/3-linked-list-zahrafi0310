using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList.ManajemenKaryawan;
using System.Linq;

namespace LinkedList.ManajemenKaryawan.Tests;

[TestClass]
public class ManajemenKaryawanTests
{
    [TestMethod]
    public void Karyawan_CekProperti_KesamaanProperti()
    {
        var karyawan = new Karyawan("001", "Alice Johnson", "Software Developer");

        Assert.AreEqual("001", karyawan.NomorKaryawan);
        Assert.AreEqual("Alice Johnson", karyawan.Nama);
        Assert.AreEqual("Software Developer", karyawan.Posisi);
    }

    [TestMethod]
    public void KaryawanNode_CekProperti_NodeBerhasilDibuat()
    {
        var karyawan = new Karyawan("002", "Bob Smith", "HR Manager");
        var node = new KaryawanNode(karyawan);

        Assert.IsNotNull(node.Karyawan); // Verifikasi bahwa Karyawan di node tidak null
        Assert.AreEqual("Bob Smith", node.Karyawan.Nama); // Verifikasi Nama
        Assert.AreEqual("HR Manager", node.Karyawan.Posisi); // Verifikasi Posisi
        Assert.IsNull(node.Next); // Verifikasi bahwa Next null pada saat inisialisasi
        Assert.IsNull(node.prev); // Verifikasi bahwa Prev null pada saat inisialisasi
    }

    [TestMethod]
    public void KaryawanNode_HubunganNode_NodeBerhasilTerhubung()
    {
        var karyawan1 = new Karyawan("002", "Bob Smith", "HR Manager");
        var karyawan2 = new Karyawan("003", "Charlie Brown", "IT Support");

        var node1 = new KaryawanNode(karyawan1);
        var node2 = new KaryawanNode(karyawan2);

        // Menghubungkan node1 dan node2
        node1.Next = node2;
        node2.prev = node1;

        Assert.AreEqual(node2, node1.Next); // Verifikasi bahwa node1 terhubung ke node2 sebagai Next
        Assert.AreEqual(node1, node2.prev); // Verifikasi bahwa node2 terhubung ke node1 sebagai Prev
    }

    [TestMethod]
    public void TambahKaryawan_TambahSatuKaryawan_KaryawanBerhasilDitambahkan()
    {
        var daftar = new DaftarKaryawan();
        var karyawan = new Karyawan("001", "John Doe", "Manager");
        daftar.TambahKaryawan(karyawan);

        string hasil = daftarKaryawan.TampilDaftarKaryawan();
        Assert.IsTrue(hasil.Contains("John Doe")); // Verifikasi bahwa karyawan berhasil ditambahkan
    }

    [TestMethod]
    public void HapusKaryawan_HapusKaryawanYangAda_KaryawanBerhasilDihapus()
    {
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        bool penghapusanBerhasil = daftar.HapusKaryawan("001");

        Assert.IsTrue(penghapusanBerhasil); // Verifikasi bahwa penghapusan berhasil
        Assert.IsTrue(string.IsNullOrEmpty(daftarKaryawan.TampilkanDaftar())); // Verifikasi daftar karyawan kosong setelah penghapusan
    }

    [TestMethod]
    public void HapusKaryawan_HapusKaryawanYangTidakAda_PenghapusanGagal()
    {
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        bool penghapusanBerhasil = daftar.HapusKaryawan("002"); // Mencoba menghapus karyawan yang tidak ada

        Assert.IsFalse(penghapusanBerhasil); // Verifikasi bahwa penghapusan gagal
    }

    [TestMethod]
    public void CariKaryawan_MencariKaryawanYangAda_KaryawanDitemukan()
    {
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        var hasilCari = daftar.CariKaryawan("John");

        Assert.AreEqual(1, hasilCari.lenght); // Verifikasi bahwa satu karyawan ditemukan
        Assert.AreEqual("John Doe", hasilCari[0].Nama); // Verifikasi bahwa nama karyawan sesuai
    }

    [TestMethod]
    public void CariKaryawan_MencariKaryawanDenganKataKunciTidakAda_KaryawanTidakDitemukan()
    {
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        var hasilCari = daftar.CariKaryawan("Jane");

        Assert.AreEqual(0, hasil.Length); // Verifikasi bahwa tidak ada karyawan yang ditemukan
    }

    [TestMethod]
    public void TampilkanDaftar_TampilkanDaftarKaryawan_DaftarDitampilkanDenganBenar()
    {
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftar.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));

        string hasil = daftarKaryawan.TampilDaftarKaryawan();
        Assert.IsTrue(hasil.StartsWith("002; Jane Doe; HR")); // Verifikasi bahwa karyawan terakhir yang ditambahkan tampil pertama
        Assert.IsTrue(hasil.EndsWith("001; John Doe; Manager")); // Verifikasi bahwa karyawan pertama yang ditambahkan tampil terakhir
    }
}
