using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RekamMedisAppBaru.Data;
using RekamMedisAppBaru.Models;
using System.Threading.Tasks;

namespace RekamMedisAppBaru.Controllers
{
    public class PatientsController : Controller
    {
        private readonly RekamMedisContext _context;

        public PatientsController(RekamMedisContext context)
        {
            _context = context;
        }

        // GET: Patients/Cetak
        public async Task<IActionResult> Cetak()
        {
            var data = await _context.Patients.ToListAsync();

            return View(data);
        }

        // Action Method "Index" (GET /Patients)
        public async Task<IActionResult> Index()
        {
            var daftarPasien = await _context.Patients.ToListAsync();

            return View(daftarPasien);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Nama,Nik,TanggalLahir,Status,Pekerjaan,Pendidikan,JenisKelamin,Agama,NoTelp,Alamat")] Pasien pasien)
        {
            // Hapus IdPasien dari Bind jika itu adalah Primary Key dan Auto-Increment
            // Biarkan database yang mengaturnya.

            // created_at dan updated_at biasanya diatur oleh database
            // Jika tidak, Anda bisa atur di sini:
            // pasien.CreatedAt = DateTime.Now;
            // pasien.UpdatedAt = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pasien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data: " + ex.Message);
            }

            // Jika gagal, kembalikan ke form dengan data yang sudah diisi
            return View(pasien);
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Temukan pasien berdasarkan IdPasien
            // (Ganti 'IdPasien' dengan nama properti Primary Key Anda)
            var pasien = await _context.Patients
                .FirstOrDefaultAsync(m => m.IdPasien == id);

            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasien = await _context.Patients.FindAsync(id); // FindAsync bekerja dengan Primary Key
            if (pasien == null)
            {
                return NotFound();
            }
            return View(pasien);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdPasien,Nama,Nik,TanggalLahir,Status,Pekerjaan,Pendidikan,JenisKelamin,Agama,NoTelp,Alamat")] Pasien pasien)
        {
            // Pastikan ID dari URL sama dengan ID dari form
            if (id != pasien.IdPasien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atur 'updated_at' jika perlu
                    // pasien.UpdatedAt = DateTime.Now;

                    _context.Update(pasien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Ini adalah error-handling jika data tidak ada
                    if (!_context.Patients.Any(e => e.IdPasien == pasien.IdPasien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Kembali ke daftar jika sukses
            }
            return View(pasien); // Kembali ke form jika gagal validasi
        }
        
        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasien = await _context.Patients
                .FirstOrDefaultAsync(m => m.IdPasien == id);
            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien); // Kirim data pasien ke view konfirmasi
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasien = await _context.Patients.FindAsync(id);
            if (pasien != null)
            {
                _context.Patients.Remove(pasien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}