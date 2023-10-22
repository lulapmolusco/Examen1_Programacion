using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos
{
    internal class cMenu
    {
        private cEmpleado[] Empleados;

        public cMenu(int NumeroE)
        {
            Empleados = new cEmpleado[NumeroE];
        }
        public void DesplegarMenu()
        {
            int Opcion;
            do
            {
                Console.WriteLine("\n Menú principal.");
                Console.WriteLine("1. Agregar Empleados.");
                Console.WriteLine("2. Consultar Empleados.");
                Console.WriteLine("3. Modificar Empleados.");
                Console.WriteLine("4. Borrar Empleados.");
                Console.WriteLine("5. Inicializar Arreglos.");
                Console.WriteLine("6. Reportes.");
                Console.WriteLine("7. Salir.");

                if (int.TryParse(Console.ReadLine(), out Opcion))
                {
                    switch (Opcion)
                    {
                        case 1:
                            AgregarE();
                            break;
                        case 2:
                            ConsultarE();
                            break;
                        case 3:
                            ModificarE();
                            break;
                        case 4:
                            BorrarE();
                            break;
                        case 5:
                            InicializarA();
                            break;
                        case 6:
                            ReportesSub();
                            break;
                        case 7:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\t \n Opcion no existe.");
                }
            } while (Opcion != 7);
        }

        private void AgregarE()
        {
            Console.Clear(); 
            
            for (int i = 0; i < Empleados.Length; i++)
            {
                if (Empleados[i] == null)
                {
                    Console.Write("Cédula: ");
                    string cedula = Console.ReadLine();

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Dirección: ");
                    string direccion = Console.ReadLine();

                    Console.Write("Teléfono: ");
                    string telefono = Console.ReadLine();

                    Console.Write("Salario: ");

                    if (double.TryParse(Console.ReadLine(), out double salario))
                    {
                        Empleados[i] = new cEmpleado(cedula, nombre, direccion, telefono, salario);
                        Console.WriteLine("El empleado ha sido agregado con exito.");
                        return;
                    }
                }
            }
            Console.WriteLine("No se puede agregar a mas empleados.");
        }
        private void ConsultarE()
        {
            Console.Clear();
            
            Console.WriteLine("\n Consultar Empleados.");

            Console.Write("Digite la cédula del empleado: ");
            string cedula = Console.ReadLine();

            cEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                Console.WriteLine("Información del empleado: ");
                MostrarInformacionE(empleado);
            }
            else
            {
                Console.WriteLine("El empleado que busca no ha sido localizado.");
            }
        }
        private cEmpleado ConsultarEmpleadoPorCedula(string cedula)
        {
            return Empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
        }
        private void ModificarE()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Modificar Empleados.");

            Console.Write("Digite la cédula del empleado: ");
            string cedula = Console.ReadLine();

            cEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                Console.WriteLine("Información actual del empleado: ");
                MostrarInformacionE(empleado);

                Console.WriteLine("Ingrese los nuevos datos.");
                Console.Write("Nombre: ");

                empleado.Nombre = Console.ReadLine();
                Console.Write("Dirección: ");

                empleado.Direccion = Console.ReadLine();
                Console.Write("Teléfono: ");

                empleado.Telefono = Console.ReadLine();
                Console.Write("Salario: ");

                if (double.TryParse(Console.ReadLine(), out double salario))
                {
                    empleado.Salario = salario;
                    Console.WriteLine("El empleado ha sido modificado con exito.");
                }
                else
                {
                    Console.WriteLine("No se pudo realizar la modificación.");
                }
            }
            else
            {
                Console.WriteLine("No se ha podido realizar la motificacion. Intentelo de nuevo.");
            }
        }
        private void BorrarE()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Borrar Empleados.");

            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();

            cEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);
            if (empleado != null)
            {
                for (int i = 0; i < Empleados.Length; i++)
                {
                    if (Empleados[i] != null && Empleados[i].Cedula == cedula)
                    {
                        Empleados[i] = null;
                        Console.WriteLine("El empleado ha sido borrado con exito.");
                        return;
                    }
                }
            }
            Console.WriteLine("El empleado que busca no ha sido localizado.");
        }
        private void InicializarA()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Inicializar Arreglo.");

            Console.Write("Digite la cantidad de empleados: ");
            if (int.TryParse(Console.ReadLine(), out int cantidadE))
            {
                Empleados = new cEmpleado[cantidadE];
                Console.WriteLine($"Arreglo inicializado con {cantidadE} empleados.");
            }
            else
            {
                Console.WriteLine("Cantidad no válida. Inténtelo de nuevo.");
            }
        }
        private void ReportesSub()
        {
            Console.Clear(); 
            
            int opcion;
            do
            {
                Console.WriteLine("\n Menú de Reportes.");
                Console.WriteLine("1. Consultar empleados.");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ConsultarE();
                            break;
                        case 2:
                            ListarEmpleados();
                            break;
                        case 3:
                            CalcularPromedioS();
                            break;
                        case 4:
                            CalcularSalarioMM();
                            break;
                        case 5:
                            Console.WriteLine("Menú Principal.");
                            break;
                        default:
                            Console.WriteLine("Opción no existe. Inténtelo de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no existe. Inténtelo de nuevo.");
                }
            } while (opcion != 5);
        }
        private void ListarEmpleados()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Listar a los empleados por su nombre.");

            var empleadosOrdenados = Empleados.Where(e => e != null)
            .OrderBy(e => e.Nombre, StringComparer.OrdinalIgnoreCase)
            .ToList();

            foreach (var empleado in empleadosOrdenados)
            {
                MostrarInformacionE(empleado);
            }
        }
        private void CalcularPromedioS()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Calcular el promedio de los salarios.");

            double totalSalarios = Empleados.Where(e => e != null).Sum(e => e.Salario);
            int contador = Empleados.Count(e => e != null);

            if (contador > 0)
            {
                double promedio = totalSalarios / contador;
                Console.WriteLine($"El promedio de salarios es: {promedio:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular el promedio.");
            }
        }
        private void CalcularSalarioMM()
        {
            Console.Clear(); 
            
            Console.WriteLine("\n Calcular el salario máximo y el salario mínimo.");

            var empleadosValidos = Empleados.Where(e => e != null).ToList();

            if (empleadosValidos.Count > 0)
            {
                double salarioMaximo = empleadosValidos.Max(e => e.Salario);
                double salarioMinimo = empleadosValidos.Min(e => e.Salario);

                Console.WriteLine($"El salario más alto es: {salarioMaximo:C}");
                Console.WriteLine($"El salario más bajo es: {salarioMinimo:C}");
            }
            else
            {
                Console.WriteLine("No se puede calcular el salario en estos momentos.");
            }
        }
        private void MostrarInformacionE(cEmpleado empleado)
        {
            Console.Clear(); 
            
            Console.WriteLine($"Cédula: {empleado.Cedula}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Dirección: {empleado.Direccion}");
            Console.WriteLine($"Teléfono: {empleado.Telefono}");
            Console.WriteLine($"Salario: {empleado.Salario:C}");
        }
    }
}
