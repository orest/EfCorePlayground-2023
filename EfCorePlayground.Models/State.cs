using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCorePlayground.Models {
    //States
    public class State {
        public string StateCode  { get; set; } //2 digits, primary key
        public string StateName { get; set; } // 100 Length

    }
}
