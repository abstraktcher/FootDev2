using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootDev2.AppData
{
    class AppDataClass
    {
       public static FootDevEntities context { get; } = new FootDevEntities();
    }
}
