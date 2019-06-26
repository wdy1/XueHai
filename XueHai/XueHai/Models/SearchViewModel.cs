using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XueHai.Models
{
    public class SearchViewModel
    {
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
        public IEnumerable<Post> Post1 { get; set; }
        public IEnumerable<Goods> Goods1 { get; set; }
        public IEnumerable<Video> Video1 { get; set; }
    }
}