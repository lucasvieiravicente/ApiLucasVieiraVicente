using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Domain
{
    public enum GameGenre
    {
        [Display(Name = "Não selecionado")]
        NotValid,
        [Display(Name = "Ação")]
        Action,
        [Display(Name = "Aventura")]
        Adventure,
        [Display(Name = "Sobrevivencia")]
        Survival,
        [Display(Name = "Luta")]
        Fighting,
        [Display(Name = "Simulador")]
        Simulation,
        [Display(Name = "Esporte")]
        Sports
    }
}
