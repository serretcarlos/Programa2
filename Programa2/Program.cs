using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa2
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivos = "";
            //se leen los archivos a procesar 
            archivos = Console.ReadLine();
            Controller controlador = new Controller(archivos);
            controlador.ProcesarArchivos();
            Console.ReadLine();
        }
    }
}
