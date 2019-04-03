namespace VkApiSDK.Abstraction
{
    public interface IDataProvider<T>
    {
        bool SaveObject(T Obj, string Name);

        bool LoadObject(out T obj, string Name);

        bool DeleteObject(string Name);
    }
}
