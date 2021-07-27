using DIO.Series;

namespace DIO.Series.Factory
{
    public static class RepositorioFactory
    {
        public static IRepositorio<T> Repositorio<T>(){
            if(typeof(T) == typeof(Serie)) return (IRepositorio<T>) new SerieRepositorio();
            
            return null;
        }
    }
}