namespace VkApiSDK.Interfaces
{
    public interface IDataProvider
    {
        bool SaveObject(object Obj, string Name);

        bool LoadObject(out object obj, string Name);
    }
}
