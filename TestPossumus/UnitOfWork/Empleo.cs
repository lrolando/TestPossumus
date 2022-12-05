using System;
using System.Collections.Generic;

namespace TestPossumus.UnitOfWork;

public partial class Empleo
{
    public int Id { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Periodo { get; set; }

    public virtual ICollection<Candidato> Candidatos { get; } = new List<Candidato>();
}
