using System.Xml.Linq;

namespace gestor_stock_clientes
{
    public class Pieza
    {
        private int cif;

        public Pieza(int numero)
        {
            this.cif = numero;
        }

        public XElement toXML()
        {
            XElement toret = new XElement("pieza"); 
            toret.SetValue(this.CIF);
            return toret;
        }
        
        public int CIF
        {
            get => this.cif;
        }
    }
    
}