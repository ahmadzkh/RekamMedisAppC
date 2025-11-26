using System;
using System.Collections.Generic;

namespace RekamMedisAppBaru.Models;

public partial class Rekammedis
{
    public int IdReport { get; set; }

    public int PasienId { get; set; }

    public int DokterId { get; set; }

    public string Keluhan { get; set; } = null!;

    public string Diagnosa { get; set; } = null!;

    public string Kondisi { get; set; } = null!;

    public DateTime TanggalDiagnosa { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Tenagamedis Dokter { get; set; } = null!;

    public virtual Pasien Pasien { get; set; } = null!;
}
