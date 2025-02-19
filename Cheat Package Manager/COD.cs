using JRPC_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDevkit;

namespace Cheat_Package_Manager
{
    public static class COD
    {
    }
    public static partial class MW
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x82239FD0, (object)0, (object)command);
        }
    }
    public static partial class WAW
    {
        public static void Cbuf_AddTextSP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 2183452896, (object)0, (object)command);
        }
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 2183593736U, (object)0, (object)command);
        }
    }
    public static partial class MW2
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x82224990, (object)0, (object)command);
        }
    }
    public static partial class BO
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x824015E0, (object)0, (object)command);
        }
        public static void Cbuf_AddTextSP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x8230FD58, (object)0, (object)command);
        }
    }
    public static partial class MW3
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x82287F68, (object)0, (object)command);
        }
    }
    public static partial class BO2
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x824015E0, (object)0, (object)command);
        }
    }
    public static partial class Ghosts
    {
        public static void Cbuf_AddTextMP(IXboxConsole xbc, string command)
        {
            int num = (int)xbc.Call<uint>(JRPC.ThreadType.Title, 0x8244C738, (object)0, (object)command);
        }
    }
}
