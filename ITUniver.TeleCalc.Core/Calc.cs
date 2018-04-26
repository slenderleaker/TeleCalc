using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITUniver.TeleCalc.Core.Operations;
using System.Reflection;

namespace ITUniver.TeleCalc.Core
{
    public class Calc
    {
        private IOperation[] operations { get; set; }

        public IEnumerable<string> getOperNames()
        {
            return operations.Select(o => o.Name);
        }
        public Calc()
        {
            var opers = new List<IOperation>();
            //Получаем текущую сборку
            var assembly = Assembly.GetExecutingAssembly();
            //var assembly = Assembly.Load("Z:/Univer/");
            //Из сборки получаем все типы
            var classes = assembly.GetTypes();

            foreach (var item in classes)
            {
                //Получаем интерфейсы, реализуемые классом
                var interfaces = item.GetInterfaces();
                //проверяет, имеет ли заданное имя хотя бы один из интерфейсов
                var isOperation = interfaces.Any(i => i == typeof(IOperation));

                if (isOperation)
                {
                    var obj = System.Activator.CreateInstance(item) as IOperation;
                    if (obj != null)
                    {
                        opers.Add(obj);
                    }
                }
            }
            operations = opers.ToArray();
        }

        public double Exec(string opName, IEnumerable<double> args)
        {
            IOperation operation = operations
                 .FirstOrDefault(o => o.Name == opName);
            if (operation == null)
                return double.NaN;

            operation.Args = args.ToArray();
            return (double)operation.Result;
        }

        [Obsolete(" ")]
        public double Exec(string opName, double x, double y)
        {
              
            return Exec(opName, new double[] { x, y });
        }

        #region OldOperations
        public int Sum(int x, int y)
        {
            return x + y;
        }
        public double Sum(double x, double y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public int Mul(int x, int y)
        {
            return x * y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public int Div(int x, int y)
        {
            return x / y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
        
        public double Exp(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }
        #endregion
    }
}
