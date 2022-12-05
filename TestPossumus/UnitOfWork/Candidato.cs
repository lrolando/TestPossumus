using System;
using System.Collections.Generic;

namespace TestPossumus.UnitOfWork;

public partial class Candidato
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaDeNacimiento { get; set; }

    public string? Email { get; set; }

    public decimal? Telefono { get; set; }

    public int? IdEmpleo { get; set; }

    public virtual Empleo? IdEmpleoNavigation { get; set; }
}
