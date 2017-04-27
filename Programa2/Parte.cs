using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa2
{
    class Parte
    {
        //atributos
        private string nombre;
        private int iTotal;
        private int iItems;
        private int iBase;
        private int iBorradas;
        private int iModificadas;
        private int iAgregadas;


        //setters y getters
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public int Total
        {
            set { iTotal = value; }
            get { return iTotal; }
        }
        public int Items
        {
            set { iItems = value; }
            get { return iItems; }
        }
        public int IBase
        {
            set { iBase = value; }
            get { return iBase; }
        }
        public int Borradas
        {
            set { iBorradas = value; }
            get { return iBorradas; }
        }
        public int Modificadas
        {
            set { iModificadas = value; }
            get { return iModificadas; }
        }
        public int Agregadas
        {
            set { iAgregadas = value; }
            get { return iAgregadas; }
        }

        //constructores

        public Parte()
        {
            this.nombre = "";
            this.iTotal = 0;
            this.iItems = 0;
            this.iBase = 0;
            this.iModificadas = 0;
            this.iBorradas = 0;
            this.iAgregadas = 0;
        }
        public Parte(string nombre, int iTotal, int iItems, int iBase, int iBorradas, int iModificadas, int iAgregadas)
        {
            this.nombre = nombre;
            this.iTotal = iTotal;
            this.iItems = iItems;
            this.iBase = iBase;
            this.iBorradas = iBorradas;
            this.iModificadas = iModificadas;
            this.iAgregadas = iAgregadas;
        }
    }
}
