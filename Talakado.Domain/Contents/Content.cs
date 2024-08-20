using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Domain.Contents
{
    public class Content
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsShow { get; set; }
    }
}
