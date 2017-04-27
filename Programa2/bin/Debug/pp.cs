//&p-Programa
//&b=13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa3
{
    class Program
    {
        //&i
        static void Main(string[] args)
        {
            string archivo;
            archivo = Console.ReadLine();
            Controlador controlador = new Controlador();
            controlador.ProcesarArchivo(archivo);
            Console.ReadLine();
        }
    }
}
