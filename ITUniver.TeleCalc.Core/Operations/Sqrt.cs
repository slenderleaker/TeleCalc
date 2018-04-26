using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.Core.Operations
{
    internal class Sqrt : IOperation
    {

        public string Name => "sqrt";

        public double[] Args
        {
            set
            {
                Result = value.Aggregate((x, y) => Math.Sqrt(x));
            }
            get
            {
                return new double[0];
            }
        }
        public string Error { get; }

        public double? Result { get; private set; }

    }


}