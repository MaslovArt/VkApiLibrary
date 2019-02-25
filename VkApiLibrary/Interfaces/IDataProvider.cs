using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Interfaces
{
    public interface IDataProvider
    {
        bool SaveObject(object Obj, string Name);

        bool LoadObject(out object obj, string Name);
    }
}
