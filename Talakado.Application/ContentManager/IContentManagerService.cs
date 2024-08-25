using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Contents;

namespace Talakado.Application.ContentManager
{
    public interface IContentManagerService
    {
        bool AddAdvertisementPhrase(string phrase, bool isShow = true);
        Content GetAdvertisementPhrase();
        bool AddPhoneNumber(string phoneNumber, bool isShow = true);
        Content GetPhoneNumber();
    }

    public class ContentManagerService : IContentManagerService
    {
        private readonly IDataBaseContext context;

        public ContentManagerService(IDataBaseContext context)
        {
            this.context = context;
        }

        public bool AddAdvertisementPhrase(string phrase, bool isShow = true)
        {
            var advertise = context.Contents.SingleOrDefault(c => c.Key == "advertisementPhrase");
            if (advertise == null)
            {
                context.Contents.Add(new Domain.Contents.Content
                {
                    Key = "advertisementPhrase",
                    Value = phrase,
                    IsShow = isShow
                });
            }
            else
            {
                advertise.Value = phrase;
                advertise.IsShow = isShow;
            }
            return context.SaveChanges() > 0;
        }

        public bool AddPhoneNumber(string phoneNumber, bool isShow = true)
        {
            var phoneNumberResult = context.Contents.SingleOrDefault(c => c.Key == "phoneNumber");
            if (phoneNumberResult == null)
            {
                context.Contents.Add(new Content
                {
                    Key = "phoneNumber",
                    Value = phoneNumber,
                    IsShow = isShow
                });
            }
            else
            {
                phoneNumberResult.Value = phoneNumber;
                phoneNumberResult.IsShow = isShow;
            }
            return context.SaveChanges() > 0;
        }
        public Content GetAdvertisementPhrase()
        {
            var advertise = context.Contents.FirstOrDefault(c => c.Key == "advertisementPhrase");
            if (advertise != null)
                return advertise;
            return null;
        }

        public Content GetPhoneNumber()
        {
            var phoneNumberResult = context.Contents.FirstOrDefault(c => c.Key == "phoneNumber");
            if (phoneNumberResult != null)
                return phoneNumberResult;
            return null;
        }
    }
}
