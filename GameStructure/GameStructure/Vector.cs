﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GameStructure
{
   
        [StructLayout(LayoutKind.Sequential)]
        public struct Vector
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Vector(double x, double y, double z)
                : this()
            {
                X = x;
                Y = y;
                Z = z;
            }

        }
    }
