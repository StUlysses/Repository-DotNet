using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WePoem.Models
{
    public class ViewModel
    {
        public string Msg { get; set; }
        public string UserID { get; set; }
        public List<Poem> PoemList { get; set; }
        public Poem Poem { get; set; }
        public User User { get; set; }
    }
}
