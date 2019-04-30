using BL.RpJobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TestGetUser
    {
        public static void Run()
        {
            var repo = new RpJobPositionRepo();
            var bl = new RpJobPositionBL();
            var b = repo.Find(x => x.Code == "123");
        }
    }
}
