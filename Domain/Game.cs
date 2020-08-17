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

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (LaunchDate == null)
                return false;

            if (string.IsNullOrEmpty(Description))
                return false;

            if (GameGenre == GameGenre.NotValid)
                return false;

            return true;
        }
    }
}
