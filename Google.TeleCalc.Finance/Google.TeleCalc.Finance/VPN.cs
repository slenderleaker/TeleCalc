using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITUniver.TeleCalc.Core.Operations;
using System.Threading;

namespace Google.TeleCalc.Finance
{
    public class VPNOperations : IOperation
    {
        public string Name => "vpn";

        public double[] Args
        {
            set
            {
                Thread.Sleep(new Random().Next(100, 3000));
                Result = new Random().Next(0, 100);
            }
            get
            { return new double[0];
            }
        }

        public string Error { get; }

        public double? Result { get; private set; }
    }
}
