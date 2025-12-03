# 🏥 Sistem Informasi Rekam Medis (Medical Record App)

Aplikasi berbasis web sederhana untuk pengelolaan data pasien dan rekam medis. Proyek ini dibuat sebagai bagian dari tugas praktikum **Rekayasa Perangkat Lunak 2 (RPL 2)** untuk mendemonstrasikan implementasi CRUD (Create, Read, Update, Delete) dan fitur pelaporan menggunakan teknologi .NET terbaru.

## 📖 Deskripsi

Aplikasi ini dirancang untuk menggantikan pencatatan data pasien manual. Dengan antarmuka yang bersih dan responsif, pengguna dapat menambahkan pasien baru, melihat detail, mengedit informasi, menghapus data, serta mencetak laporan data pasien dalam format PDF dengan layout resmi (Kop Surat).

## 🚀 Teknologi yang Digunakan (Tech Stack)

Proyek ini dibangun menggunakan teknologi modern berikut:

### Backend & Framework
* **Bahasa Pemrograman:** [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* **Framework:** ASP.NET Core MVC (.NET 8.0)
* **ORM (Object-Relational Mapping):** Entity Framework Core
* **Database Provider:** Pomelo.EntityFrameworkCore.MySql

### Database
* **Database:** MySQL (dijalankan via Laragon/XAMPP)
* **Management Tool:** phpMyAdmin / HeidiSQL

### Frontend
* **View Engine:** Razor Views (.cshtml)
* **Styling:** CSS3, Bootstrap (untuk layout responsif)
* **Printing:** Native CSS `@media print` (untuk ekspor PDF tanpa plugin eksternal)

### Tools
* **IDE:** Visual Studio 2022
* **Version Control:** Git

## ✨ Fitur Utama

1.  **Manajemen Data Pasien (CRUD):**
    * Input data pasien lengkap (Nama, NIK, Tgl Lahir, Alamat, dll).
    * Validasi form input.
    * Edit dan Hapus data dengan aman.
2.  **Laporan Siap Cetak (Reporting):**
    * Fitur cetak data ke PDF.
    * Layout khusus dengan **Kop Surat (Header)** resmi.
    * Tanda tangan digital area pada laporan.
    * Tombol cetak otomatis disembunyikan saat proses printing.

## ⚙️ Cara Menjalankan Project (Installation)

Ikuti langkah berikut untuk menjalankan proyek ini di komputer lokal Anda:

### Prasyarat
* Visual Studio 2022 (dengan workload ASP.NET and web development).
* .NET SDK 8.0.
* Laragon atau XAMPP (untuk server MySQL).

### Langkah-langkah
1.  **Clone Repository**
    Buka terminal/Git Bash dan jalankan:
    ```bash
    git clone [https://github.com/ahmadzkh/RekamMedisAppC.git](https://github.com/ahmadzkh/RekamMedisAppC.git)
    ```

2.  **Siapkan Database**
    * Nyalakan MySQL di Laragon/XAMPP.
    * Buat database baru bernama `rekam-medis` (atau sesuai konfigurasi Anda).
    * Import file SQL (jika ada) atau biarkan Entity Framework membuat tabelnya (jika menggunakan Migrations).

3.  **Konfigurasi Koneksi**
    * Buka file `appsettings.json`.
    * Sesuaikan *ConnectionString* dengan kredensial database Anda:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "server=localhost;port=3306;database=rekam-medis;user=root;password=;"
    }
    ```

4.  **Jalankan Aplikasi**
    * Buka file solution (`.sln`) di Visual Studio.
    * Tekan tombol **Play (F5)** atau pilih menu **Debug > Start Debugging**.
    * Aplikasi akan berjalan di browser pada `https://localhost:7xxx`.

## 📸 Screenshots

<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/40d91b12-aecb-42f4-9191-4ac25490bcee" />

<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/2393450b-62fa-40dc-a3ec-73caade21569" />

<img width="1920" height="1080" alt="Image" src="https://github.com/user-attachments/assets/be8268eb-7b01-40c4-9ea1-013efce095c9" />

---

**Dibuat oleh:**
Nama: Ahmad Zaky Humami
NPM: 50422138
Mata Praktikum: Rekayasa Perangkat Lunak 2
