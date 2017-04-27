using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa2
{
	//&p-Parte
	//&b=10
    class Parte
    {
        //atributos
        private string nombre;
        private int iTotal;//&m
        private int iItems;//&m
        private int iBase;
        private int iBorradas;
        private int iModificadas;
        private int iAgregadas;


        //setters y getters
	//&i
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
	//&i
        public int Total
        {
            set { iTotal = value; }
            get { return iTotal; }
        }
	//&i
        public int Items
        {
            set { iItems = value; }
            get { return iItems; }
        }
	//&i
        public int IBase
        {
            set { iBase = value; }
            get { return iBase; }
        }
	//&i
        public int Borradas
        {
            set { iBorradas = value; }
            get { return iBorradas; }
        }
	//&i
        public int Modificadas
        {
            set { iModificadas = value; }
            get { return iModificadas; }
        }
	//&i
        public int Agregadas
        {
            set { iAgregadas = value; }
            get { return iAgregadas; }
        }

        //constructores
	//&i
	//&b=4
        public Parte()
        {
            this.nombre = "";
            this.iTotal = 0;//&m
            this.iItems = 0;//&m
            this.iBase = 0;
            this.iModificadas = 0;
            this.iBorradas = 0;
            this.iAgregadas = 0;
        }
	//&i
	//&b=4
        public Parte(string nombre, int iTotal, int iItems, int iBase, int iBorradas, int iModificadas, int iAgregadas)//&m
        {
		
            this.nombre = nombre;
            this.iTotal = iTotal;//&m
            this.iItems = iItems;//&m
            this.iBase = iBase;
            this.iBorradas = iBorradas;
            this.iModificadas = iModificadas;
            this.iAgregadas = iAgregadas;
        }
    }
}
