using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa2
{
	//&p-Programa
	//&d=1
	//&b=14
    class Program
    {
	//&i
        static void Main(string[] args)
        {
            string archivos = "";
            //se leen los archivos a procesar 
            archivos = Console.ReadLine();
            Controller controlador = new Controller(archivos); //&m
            controlador.ProcesarArchivos();//&m
            Console.ReadLine();
        }
    }
}
