using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPeloID(int id);        
        void Insere(T entidade);        
        void ExcluiPeloID(int id);        
        void Atualiza(int id, T entidade);
        int ProximoID();
    }
}