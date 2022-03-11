using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransCare.Core
{
    public class BaseList<T>
    {
        public int NumberOfRecords { get; set; }

        public List<T> Data { get; set; }
    }
}
