using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Domain.Personels
{
    public class Personel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public bool IsShowAsOurTeam { get; set; }
        public string ImageAddress { get; set; }
    }
}
