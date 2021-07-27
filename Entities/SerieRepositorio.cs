using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        //Atributos
        public List<Serie> listaSeries = new List<Serie>();

        //Métodos 
        public void Atualiza(int id, Serie novoObjeto)
        {
            listaSeries[id] = novoObjeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}