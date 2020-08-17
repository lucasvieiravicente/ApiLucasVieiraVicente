using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Domain
{
    public class Game : BaseEntity
    {               
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Description { get; set; }
        public GameGenre GameGenre { get; set; }
    }
}
