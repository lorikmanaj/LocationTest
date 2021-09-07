using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediorTest.Services
{
    public interface IGeneralService<T>
    {
        T Insert();
        T Update();
        List<T> Read();
        T Delete();
    }
}
