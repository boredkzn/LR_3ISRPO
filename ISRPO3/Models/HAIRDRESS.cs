using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISRPOLR3.Models
{
    public class HAIRDRESS
    {
       public int Id { get; set; }

       public DateTime Date { get; set; }

       public string Master { get; set; }

        public string FIO_clients { get; set; }

        public string Yslyga { get; set; }
    }
}
