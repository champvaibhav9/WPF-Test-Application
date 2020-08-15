using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    public class User
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public User()
        {
            userId = id = 0;
            title = string.Empty;
            completed = false;
        }

    }
}
