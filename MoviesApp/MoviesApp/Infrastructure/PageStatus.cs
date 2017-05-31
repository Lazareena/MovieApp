using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Infrastructure
{
    public class PageStatus<T>
    {
        public bool Succeeded { get; set; }
        public Exception Ex { get; set; }
        public T Result { get; set; }
    }
}
