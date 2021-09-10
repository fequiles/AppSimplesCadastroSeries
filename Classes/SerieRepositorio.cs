using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSeries = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSeries[id] = objeto;
		}

		public void ExcluiPeloID(int id)
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

		public int ProximoID()
		{
			return listaSeries.Count;
		}

		public Serie RetornaPeloID(int id)
		{
			return listaSeries[id];
		}
	}
}