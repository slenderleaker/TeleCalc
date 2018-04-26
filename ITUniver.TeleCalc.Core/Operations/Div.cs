using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.Core.Operations
{
    internal class Div : IOperation
    {

        public string Name => "div";

        public double[] Args
        {
            set
            {
                var div = 0d;
                foreach (var item in value)
                {
                    div = div / item;

                }
                Result = div;
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