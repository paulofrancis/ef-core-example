using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ef_core_example.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
