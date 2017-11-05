using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_Weekend_Application.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public string userOne { get; set; }
        public string userTwo { get; set; }
        public Boolean isActive { get; set; }
    }
}
