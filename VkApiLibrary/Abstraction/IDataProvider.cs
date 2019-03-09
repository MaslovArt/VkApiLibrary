namespace VkApiSDK.Abstraction
{
    public interface IDataProvider
    {
        bool SaveObject<T>(T Obj, string Name);

        bool LoadObject<T>(out T obj, string Name);
    }
}
