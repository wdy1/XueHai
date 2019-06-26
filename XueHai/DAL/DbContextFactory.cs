using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbContextFactory
    {
        public static XueHaiEntities CreateDbContext()
        {
            XueHaiEntities dbContext = (XueHaiEntities)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new XueHaiEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
