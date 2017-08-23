﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
namespace Vivid.Input
{
    public class VInput
    {
        public static int MX=0, MY=0, MZ=0;
        public static int MDX=0, MDY=0, MDZ=0;
        public static bool[] MB = new bool[32];
        public static Dictionary<Key, bool> Keys = new Dictionary<OpenTK.Input.Key, bool>();
        public static bool KeyIn(Key k)
        {
            if (Keys.ContainsKey(k)) return true;
            return false;
        }
    }
}
