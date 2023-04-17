using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class MathEvent
    {
        public event EventHandler<MathEventArgs> Math;
        public void OnMathEvent(int x, int y)
        {
            if (Math != null)
            {
                var args = new MathEventArgs();
                args.x = x;
                args.y = y;
                Math(this, args);
            }
        }
    }
}
