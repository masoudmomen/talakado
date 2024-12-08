using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.ContentManager
{
    public interface IPersonelManager
    {
        List<PersonelDto> GetPersonelsList();

    }



    public class PersonelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public bool IsShowAsOurTeam { get; set; }
    }
}
