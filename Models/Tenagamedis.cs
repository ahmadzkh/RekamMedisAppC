using System;
using System.Collections.Generic;

namespace RekamMedisAppBaru.Models;

public partial class Tenagamedis
{
    public int IdDokter { get; set; }

    public string Nama { get; set; } = null!;

    public string Spesialisasi { get; set; } = null!;

    public string JenisKelamin { get; set; } = null!;

    public DateOnly TanggalLahir { get; set; }

    public string Alamat { get; set; } = null!;

    public string NoTelp { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly TanggalRegist { get; set; }

    public DateOnly? TanggalOut { get; set; }

    public string HariPraktek { get; set; } = null!;

    public string JamPraktek { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Rekammedis> Rekammedis { get; set; } = new List<Rekammedis>();
}
