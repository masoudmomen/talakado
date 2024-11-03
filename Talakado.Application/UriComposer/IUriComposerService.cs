using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.UriComposer
{
    public interface IUriComposerService
    {
        string ComposeImageUri(string src);
    }

    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string src)
        {
            if (!string.IsNullOrEmpty(src) && !src.StartsWith("https://localhost:7238/"))
                return "https://localhost:7238/" + src;
            return src;
        }
    }
}
