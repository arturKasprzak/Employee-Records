using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L18_1_Ewidencja
{
    class Driver: Employee
    {
        double numbersOfKilometers;

        static readonly double averageMonthlyNumberOfKm = 8000;
        public Driver(string im, string nz, double lg, 
                      double st, double lk): base(im,nz,lg,st)
        {
            numbersOfKilometers = lk;
        }
        public Driver(string[] tab): base(tab[0],tab[1],double.Parse(tab[2]),double.Parse(tab[3]))
        {
            numbersOfKilometers = double.Parse(tab[4]);
        }

        protected override double CalculateBonuses()
        {
            double percentBonuses = 0.10;
            if (numbersOfKilometers > averageMonthlyNumberOfKm)
            {
                percentBonuses = 0.20;
            }
            return base.CalculateBasic() * percentBonuses;
        }
        
        public override string ToString()
        {
            return base.ToString() +
                String.Format("{0,-10}", numbersOfKilometers );
        }
        public override string TextToFile()
        {
            return base.TextToFile() +
                String.Format(";{0}", numbersOfKilometers);
        }
        protected override string LastColumnHeader()
        {
            return String.Format(";{0}", "Kilometers");
        }
    }
}
