using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern {
    public partial class NativeMethods {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDeallocate"></param>
        public static void WebPSafeFree(IntPtr toDeallocate)
        {
            WebPFree(toDeallocate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDeallocate"></param>
        [DllImportAttribute("libwebp", EntryPoint = "WebPFree", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WebPFree(IntPtr toDeallocate);
    }
}