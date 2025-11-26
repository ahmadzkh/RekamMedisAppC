using System;
using System.Collections.Generic;

namespace RekamMedisAppBaru.Models;

public partial class Pasien
{
    public int IdPasien { get; set; }

    public string Nama { get; set; } = null!;

    public string Nik { get; set; } = null!;

    public DateOnly TanggalLahir { get; set; }

    public string Status { get; set; } = null!;

    public string Pekerjaan { get; set; } = null!;

    public string Pendidikan { get; set; } = null!;

    public string JenisKelamin { get; set; } = null!;

    public string Agama { get; set; } = null!;

    public string NoTelp { get; set; } = null!;

    public string Alamat { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Rekammedis> Rekammedis { get; set; } = new List<Rekammedis>();
}
