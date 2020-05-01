using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L18_1_Ewidencja
{
    class Seller : Employee
    {
        double turnoverValue;
        static readonly double averageMonthlyTurnover = 100000;
        public Seller(string im, string nz, double lg,
                      double st, double wo): base(im,nz,lg,st)
        {
            turnoverValue = wo;
        }
        public Seller(string[] tab): base(tab[0],tab[1],double.Parse(tab[2]),double.Parse(tab[3]))
        {
            turnoverValue = double.Parse(tab[4]);
        }

        protected override double CalculateBonuses()
        {
            double percentBonuses = 0.30;
            if (turnoverValue > averageMonthlyTurnover)
            {
                percentBonuses = 0.40;
            }
            return base.CalculateBasic() * percentBonuses;
        }
       
        public override string ToString()
        {
            return base.ToString() +
                String.Format("{0,-10}", turnoverValue);
        }
        public override string TextToFile()
        {
            return base.TextToFile() +
                String.Format(";{0}", turnoverValue);
        }

        protected override string LastColumnHeader()
        {
            return String.Format(";{0}", "Obrót");
        }
    }
}
