using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IUserGuanzhu
    {
        IEnumerable<UserGuanzhu> CountUserGuanzhu1ById(int uid);
        IEnumerable<UserGuanzhu> CountUserGuanzhu2ById(int uid);
    }
}
