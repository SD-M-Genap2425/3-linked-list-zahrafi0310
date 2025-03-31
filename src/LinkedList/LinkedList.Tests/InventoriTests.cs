using LinkedList.Inventori;
using System.Text;

namespace LinkedListInventori.Inventori.Tests;

[TestClass]
public class InventoriTests
{
    [TestMethod]
    public void Item_CekProperti_KesetaraanProperti()
    {
        var item = new item("Apple", 50);

        Assert.AreEqual("Apple", item.Nama);
        Assert.AreEqual(50, item.Kuantitas);
    }

    [TestMethod]
    public void TambahItem_TambahSatuItem_ItemBerhasilDitambahkan()
    {
        var manajemen = new ManajemenInventori();
        var item = new item("Apple", 50);
        manajemen.TambahItem(item);

        string hasil = manajemenInventori.TampilkanInventori();
        Assert.IsTrue(hasil.Contains("Apple; 50")); // Verifikasi bahwa item berhasil ditambahkan
    }

    [TestMethod]
    public void HapusItem_HapusItemYangAda_ItemBerhasilDihapus()
    {
        var manajemen = new ManajemenInventori();
        manajemen.TambahItem(new item("Apple", 50));
        bool penghapusanBerhasil = manajemen.HapusItem("Apple");

        Assert.IsTrue(penghapusanBerhasil); // Verifikasi bahwa penghapusan berhasil
        Assert.IsTrue(string.IsNullOrEmpty(manajemenInventori.TampilInventori())); // Verifikasi daftar inventori kosong setelah penghapusan
    }

    [TestMethod]
    public void HapusItem_HapusItemYangTidakAda_PenghapusanGagal()
    {
        var manajemen = new ManajemenInventori();
        manajemen.TambahItem(new item("Apple", 50));
        bool penghapusanBerhasil = manajemen.HapusItem("Orange"); // Mencoba menghapus item yang tidak ada

        Assert.IsFalse(penghapusanBerhasil); // Verifikasi bahwa penghapusan gagal
        Assert.IsFalse(string.IsNullOrEmpty(manajemenInventori.TampilkanInventori())); // Verifikasi bahwa inventori masih mengandung item
    }

    [TestMethod]
    public void TampilkanInventori_TampilkanDaftarItem_DaftarDitampilkanDenganBenar()
    {
        var manajemen = new ManajemenInventori();
        manajemen.TambahItem(new item("Apple", 50));
        manajemen.TambahItem(new item("Banana", 30));

        string hasil = manajemenInventori.TampilkanInventori();

        // Membangun string yang diharapkan
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Apple; 50");
        sb.AppendLine("Banana; 30");
        string hasilDiharapkan = sb.ToString().TrimEnd();

        Assert.AreEqual(hasilDiharapkan, hasil); // Verifikasi bahwa daftar inventori ditampilkan dengan benar
    }
}
