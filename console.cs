using System;
using System.Collections.Generic;

class Tanaman
{
    private string nama;
    private int waktuTumbuh;
    private bool sudahDipanen;

    public Tanaman(string nama, int waktuTumbuh)
    {
        this.nama = nama;
        this.waktuTumbuh = waktuTumbuh;
        this.sudahDipanen = false;
    }

    public string Nama => nama;
    public int WaktuTumbuh => waktuTumbuh;
    public bool SudahDipanen => sudahDipanen;

    public virtual void TampilkanInfo()
    {
        Console.WriteLine($"{Nama} - Waktu Tumbuh: {WaktuTumbuh} hari - Status: {(sudahDipanen ? "Sudah Dipanen" : "Belum Dipanen")}");
    }

    public virtual void Panen()
    {
        if (!sudahDipanen)
        {
            sudahDipanen = true;
            Console.WriteLine($"{Nama} telah dipanen.");
        }
        else
        {
            Console.WriteLine($"{Nama} sudah pernah dipanen.");
        }
    }
}

class TanamanBuah : Tanaman
{
    public TanamanBuah(string nama, int waktuTumbuh) : base(nama, waktuTumbuh) { }

    public override void Panen()
    {
        Console.WriteLine($"Buah {Nama} telah dipanen.");
        base.Panen();
    }
}

class TanamanSayur : Tanaman
{
    public TanamanSayur(string nama, int waktuTumbuh) : base(nama, waktuTumbuh) { }

    public override void Panen()
    {
        Console.WriteLine($"Sayur {Nama} telah dipanen.");
        base.Panen();
    }
}

class Petani
{
    private string nama;

    public Petani(string nama)
    {
        this.nama = nama;
    }
    public string Nama => nama;
}

class Perkebunan
{
    private List<Tanaman> daftarTanaman = new List<Tanaman>();
    private List<Petani> daftarPetani = new List<Petani>();

    public void TambahPetani(Petani petani)
    {
        daftarPetani.Add(petani);
    }

    public void Tanam(Tanaman tanaman, Petani petani = null)
    {
        daftarTanaman.Add(tanaman);
        if (petani != null)
        {
            Console.WriteLine($"{petani.Nama} telah menanam {tanaman.Nama} di perkebunan.");
        }
        else
        {
            Console.WriteLine($"{tanaman.Nama} telah ditanam di perkebunan.");
        }
    }

    public void TampilkanTanaman()
    {
        Console.WriteLine("\nDaftar Tanaman di Perkebunan:");
        foreach (var tanaman in daftarTanaman)
        {
            tanaman.TampilkanInfo();
        }
    }

    public void PanenTanaman(string namaTanaman)
    {
        var tanaman = daftarTanaman.Find(t => t.Nama.ToLower() == namaTanaman.ToLower());
        if (tanaman != null)
        {
            tanaman.Panen();
        }
        else
        {
            Console.WriteLine($"Tanaman {namaTanaman} tidak ditemukan.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perkebunan perkebunan = new Perkebunan();

        Console.WriteLine("Sistem Manajemen Perkebunan");

        Console.Write("Masukkan nama petani pertama: ");
        string namaPetani1 = Console.ReadLine();
        Petani petani1 = new Petani(namaPetani1);
        perkebunan.TambahPetani(petani1);

        Console.Write("Masukkan nama petani kedua: ");
        string namaPetani2 = Console.ReadLine();
        Petani petani2 = new Petani(namaPetani2);
        perkebunan.TambahPetani(petani2);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tanam tanaman");
            Console.WriteLine("2. Lihat semua tanaman");
            Console.WriteLine("3. Panen tanaman");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                Console.Write("Masukkan jenis tanaman (buah/sayur): ");
                string jenis = Console.ReadLine().ToLower();
                Console.Write("Masukkan nama tanaman: ");
                string namaTanaman = Console.ReadLine();
                Console.Write("Masukkan waktu tumbuh (hari): ");
                int waktu = int.Parse(Console.ReadLine());

                Console.Write("Siapa yang menanam (1 untuk {0}, 2 untuk {1}, selain itu tanpa petani)? ", petani1.Nama, petani2.Nama);
                string pilihPetani = Console.ReadLine();

                Tanaman tanamanBaru;
                if (jenis == "buah")
                    tanamanBaru = new TanamanBuah(namaTanaman, waktu);
                else
                    tanamanBaru = new TanamanSayur(namaTanaman, waktu);

                if (pilihPetani == "1")
                    perkebunan.Tanam(tanamanBaru, petani1);
                else if (pilihPetani == "2")
                    perkebunan.Tanam(tanamanBaru, petani2);
                else
                    perkebunan.Tanam(tanamanBaru);
            }
            else if (pilihan == "2")
            {
                perkebunan.TampilkanTanaman();
            }
            else if (pilihan == "3")
            {
                Console.Write("Masukkan nama tanaman yang ingin dipanen: ");
                string namaPanen = Console.ReadLine();
                perkebunan.PanenTanaman(namaPanen);
            }
            else if (pilihan == "4")
            {
                Console.WriteLine("Terima kasih telah menggunakan sistem manajemen perkebunan!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }
    }
}
