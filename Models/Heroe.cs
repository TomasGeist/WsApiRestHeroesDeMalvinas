using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiRestHeroesDeMalvinas.Models;

public partial class Heroe
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(300, MinimumLength = 5, ErrorMessage = "Máximo 300 caracteres")]
    public string NombreCompleto { get; set; } = null!;

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Máximo 25 caracteres")]
    public string Documento { get; set; } = null!;

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Máximo 200 caracteres")]
    public string Fuerza { get; set; } = null!;

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Máximo 200 caracteres")]
    public string Grado { get; set; } = null!;

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Máximo 80 caracteres")]
    public string Vive { get; set; } = null!;

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Máximo 120 caracteres")]
    public string Condicion { get; set; } = null!;
}