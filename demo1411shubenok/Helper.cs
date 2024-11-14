using demo1411shubenok.Context;
using demo1411shubenok.Models;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1411shubenok
{
    public static class Helper
    {

        public static readonly User11019Context user11019Context = new User11019Context();
        public static Client currUser;
        public static bool isGuest = false;

    }
}
