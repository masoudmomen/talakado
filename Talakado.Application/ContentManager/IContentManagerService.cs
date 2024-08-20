﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;

namespace Talakado.Application.ContentManager
{
    public interface IContentManagerService
    {
        void AddAdvertisementPhrase(string phrase, bool isShow = true);
        string GetAdvertisementPhrase();
    }

    public class ContentManagerService : IContentManagerService
    {
        private readonly IDataBaseContext context;

        public ContentManagerService(IDataBaseContext context)
        {
            this.context = context;
        }

        public void AddAdvertisementPhrase(string phrase, bool isShow = true)
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
            context.SaveChanges();
        }

        public string GetAdvertisementPhrase()
        {
            var advertise = context.Contents.FirstOrDefault(c => c.Key == "advertisementPhrase");
            if (advertise != null && advertise.IsShow)
                return advertise.Value;
            return "";
        }
    }
}
