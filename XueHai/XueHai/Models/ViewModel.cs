using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XueHai.Models
{
      public class ViewModel
        {
            public Comments c;
            public IEnumerable<Reply> Rs;
            public int PraStatus;
            public IList<Reply> Ps;
        }
}