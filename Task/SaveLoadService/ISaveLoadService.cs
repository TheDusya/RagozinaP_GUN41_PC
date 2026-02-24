namespace Task.SaveLoadService
{
    public interface ISaveLoadService<T>
    {
        void Save(T data, string id);
        T Load(string id);
    }
}
