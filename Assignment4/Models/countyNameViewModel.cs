using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ISM6225_Assignment4.Models
{
    public class countyNameViewModel
    {
        public List<Attributes> FishingAreas { get; set; }
        public SelectList Countys { get; set; }
        public string countyName { get; set; }
        public string SearchString { get; set; }
    }
}
