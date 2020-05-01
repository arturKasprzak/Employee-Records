using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L18_1_Ewidencja
{
    public abstract class Employee: IComparable<Employee>
    {
        public string name;
        public string lastname;
        double countWorkHours;
        double hourlyRate;

        public Employee(string im, string nz, double lg, double st)
        {
            name = im;
            lastname = nz;
            countWorkHours = lg;
            hourlyRate = st;
        }

        protected virtual double CalculateBasic()
        {
            return countWorkHours * hourlyRate;
        }

        protected abstract double CalculateBonuses();
        protected abstract string LastColumnHeader();

        // Interface implementation IComparable
        public int CompareTo(Employee obj)
        {
            int result = lastname.CompareTo(obj.lastname);
            if (result == 0)
                result = name.CompareTo(obj.name);
            return result;
        }

        public static string ColumnHeader(Department department)
        {
            string lastColumns = (department == Department.drivers) ? "Kilometers" : "Target";
            return String.Format("{0,-10}{1,-10}{2,-8}{3,-10}{4,-14}{5,-8}{6,5}",
              "Name","Last Name","Hours","Rate","Basic Salary", "Bonus", lastColumns);
        }
        public override string ToString()
        {
            return String.Format("{0,-10}{1,-10}{2,-8:F2}{3,-10:F2}{4,-14:F2}{5,-8:F2}",
                name, lastname, countWorkHours, hourlyRate,
                CalculateBasic(),CalculateBonuses());
        }
        public virtual string TextToFile()
        {
            return String.Format("{0};{1};{2};{3};{4};{5}",
                name, lastname, countWorkHours, hourlyRate,
                CalculateBasic(), CalculateBonuses());
        }
    }
}
