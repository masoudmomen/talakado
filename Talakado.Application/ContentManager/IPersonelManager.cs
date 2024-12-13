using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Personels;

namespace Talakado.Application.ContentManager
{
    public interface IPersonelManager
    {
        List<PersonelDto> GetPersonelsList();
        PersonelDto? AddPersonel(PersonelDto personel);
    }
    public class PersonelManager: IPersonelManager
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public PersonelManager(IDataBaseContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PersonelDto? AddPersonel(PersonelDto personel)
        {
            if (personel == null) return null;
            var result = mapper.Map<Personel>(personel);
            context.Personels.Add(result);
            context.SaveChanges();
            return mapper.Map<PersonelDto?>(result);
        }

        public List<PersonelDto> GetPersonelsList()
        {
            return mapper.Map<List<PersonelDto>>(context.Personels.ToList());
        }
    }


    public class PersonelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public bool IsShowAsOurTeam { get; set; }
        public string ImageAddress { get; set; }
    }
}
