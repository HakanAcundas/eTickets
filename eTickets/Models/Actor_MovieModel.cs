using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor_MovieModel
    {
        public int MovieID { get; set; }
        public MovieModel Movie { get; set; }
        public int ActorID { get; set; }
        public ActorModel Actor { get; set; }
    }
}
