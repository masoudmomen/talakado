using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Application.UriComposer;
using Talakado.Domain.Personels;

namespace Talakado.Application.ContentManager
{
    public interface IPersonelManager
    {
        List<PersonelDto> GetPersonelsList();
        PersonelDto? AddPersonel(PersonelDto personel);
        PersonelDto? EditPersonel(PersonelDto personel);
        bool DeletePersonel(int id);
    }
    public class PersonelManager: IPersonelManager
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public PersonelManager(IDataBaseContext context,
            IMapper mapper,
            IUriComposerService uriComposerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }

        public PersonelDto? AddPersonel(PersonelDto personel)
        {
            if (personel == null) return null;
            var result = mapper.Map<Personel>(personel);
            context.Personels.Add(result);
            context.SaveChanges();
            return mapper.Map<PersonelDto?>(result);
        }

        public bool DeletePersonel(int id)
        {
            var person = context.Personels.Find(id);
            if (person == null) return false;
            context.Personels.Remove(person);
            return context.SaveChanges()>0;
        }

        public PersonelDto? EditPersonel(PersonelDto personel)
        {
            if (personel == null) return null;
            var person = context.Personels.Find(personel.Id);
            if (person == null) return null;
            person.Name = personel.Name;
            if(!string.IsNullOrEmpty(personel.ImageAddress)) person.ImageAddress = personel.ImageAddress;
            person.Description = personel.Description;
            person.Job = personel.Job;
            person.IsShowAsOurTeam = personel.IsShowAsOurTeam;
            if (context.SaveChanges() > 0)
            {
                return mapper.Map<PersonelDto?>(person);
            }
            return null;
        }

        public List<PersonelDto> GetPersonelsList()
        {
            var result = mapper.Map<List<PersonelDto>>(context.Personels.ToList());
            foreach (var item in result)
            {
                item.ImageAddress = uriComposerService.ComposeImageUri(item.ImageAddress);
            }
            return result;
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
