using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de gestión de empleados.");

            Console.Write("Digite la capacidad máxima de empleados: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            cMenu menu = new cMenu(capacidad);

            bool salir = false;
            while (!salir)
            {
                menu.DesplegarMenu();
                int opcion = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
