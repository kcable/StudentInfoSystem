using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class Diploma
    {
        public int diplomaId { get; set; }
        public string student { get; set; }
        public string topic { get; set; }

        public Diploma()
        {

        }

        public Diploma(string facNum)
        {
            student = facNum;
            topic = "No topic yet";
        }


    }
}
