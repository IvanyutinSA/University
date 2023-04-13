using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal interface IArithmetic
    {
        static public int Add(int x, int y) => x + y;
        static public int Sub(int x, int y) => x - y;
        static public int Prod(int x, int y) => x * y;
        static public int Div(int x, int y) => x / y;
    }
}
