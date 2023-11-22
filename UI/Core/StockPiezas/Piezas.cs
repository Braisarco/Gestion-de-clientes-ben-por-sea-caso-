using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace gestor_stock_clientes
{
    public class Piezas
    {
        private List<Pieza> listaPiezas;

        public Piezas(List<Pieza> piezas)
        {
            this.listaPiezas = piezas;
        }

        public XElement toXML()
        {
            XElement root = new XElement("piezas");
            foreach (Pieza pieza in ListaPiezas)
            {
                root.Add(pieza.toXML());
            }
            return root;
        }
        
        public List<Pieza> ListaPiezas
        {
            get => this.listaPiezas;
        }
    }
}