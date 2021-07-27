using System.Collections.Generic;

public interface IRepositorio<T>
{
    List<T> Lista();
    T RetornaPorId(int id);
    void Insere(T objeto);
    void Exclui(int id);        
    void Atualiza(int id, T novoObjeto);
    int ProximoId();
}