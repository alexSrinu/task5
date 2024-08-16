using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace task5.Models
{
    public class City
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string StateId { get; set; }
    }
}