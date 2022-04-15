using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISRPO3.Models
{
    public class Restouran
    {
       public int Id { get; set; }

       public DateTime Date_reservation { get; set; }

       public string Number_table { get; set; }

        public string FIO_clients { get; set; }

        public string Phone_clients { get; set; }
    }
}
