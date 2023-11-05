namespace Services.Contracts
{
    public interface IMapperService
    {
        T Map<T>(object obj);

        public T? MapAnything<T>(object obj);
    }
}