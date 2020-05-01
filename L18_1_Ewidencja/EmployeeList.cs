using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L18_1_Ewidencja
{
    public class EmployeeList
    {
        List<Employee> personList;
        Department department;

        public EmployeeList(Department de)
        {
            department = de;
            personList = new List<Employee>();
        }

        // Display the list on the screen
        public bool ShowList()
        {
            Console.WriteLine(Employee.ColumnHeader(department));
            personList.Sort();
            foreach (Employee pers in personList)
            {
                Console.WriteLine(pers.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Any key - save the calculated data, Esc - exit without saving");
            ConsoleKeyInfo key = Console.ReadKey(true);
            return (key.Key != ConsoleKey.Escape);
        }

        private bool correctData(string [] tab)
        {
            bool dataIsCorrect = false;
            double tmp;
            if (tab.Length == 5 && double.TryParse(tab[2], out tmp) &&
                double.TryParse(tab[3], out tmp) && double.TryParse(tab[4], out tmp))
                dataIsCorrect = true;
            return dataIsCorrect;
        }

        // Save employee list to file
        public void Save(string path)
        {
            StreamWriter sw = null;
            FileStream fs = null;
            try
            {
                fs = File.Create(path);
                sw = new StreamWriter(fs);
                foreach (Employee pers in personList)
                {
                    sw.WriteLine(pers.TextToFile());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        // Loading data from a file
        public void Load(string path)
        {
            StreamReader re = null;
            FileStream fs = null;
            try
            {
                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                    re = new StreamReader(fs);
                    string line = null;
                    while ((line = re.ReadLine()) != null)  // wyswietlenie pliku line po linii
                    {
                        string[] tab = line.Split(';');
                        if (correctData(tab))
                        {
                            if(department == Department.sellers)
                                personList.Add(new Seller(tab));
                            else if (department == Department.drivers)
                                personList.Add(new Driver(tab));
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (re != null)
                {
                    re.Close();
                }
            }
        }
    }
}
