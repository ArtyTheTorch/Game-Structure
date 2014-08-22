﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameStructure
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr hWnd;
        public Int32 msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }
    class FastLoop
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message msg,
            IntPtr hWnd,
            uint messageFilterMin,
            uint messageFilterMax,
            uint flags);

        PreciseTimer _timer = new PreciseTimer();
        public delegate void LoopCallBack(double elapsedTime);
        LoopCallBack _callback;

        public FastLoop(LoopCallBack callback)
        {
            _callback = callback;
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }
        void OnApplicationEnterIdle(object sender, EventArgs e) 
        {
            while (IsAppStillIdle())
            {
                _callback(_timer.GetElapsedTime());
            }
        }
        private bool IsAppStillIdle() 
        {
            Message msg;
            return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }
    }
}
