using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_ClassLibrary
{
    public class Class1
    {
        public int Num_a(int a)
        {
          return a;
        }

        private int Num_b(int b)
        {
            return b;
        }

        public int Num_c(int c)
        {
            return c;
        }

        protected int Num_d(int d)
        {
            return d;
        }
        
    }

    public class Class2
    {
        public string Str_a(string a)
        {
            return a;
        }

        private string Str_b(string b)
        {
            return b;
        }

        internal string Str_c(string c)
        {
            return c;
        }

        protected string Str_d(string d)
        {
            return d;
        }

    }
}
