﻿using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using Platform.Threading;
using Platform.Helpers;

namespace Platform.Communication.Protocol.Udp
{
    public static class UdpClientExtensions
    {
        private static readonly Encoding DefaultEncoding = Singleton.Get(() => Encoding.GetEncoding(0));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SendString(this UdpClient udp, IPEndPoint ipEndPoint, string message)
        {
            var bytes = DefaultEncoding.GetBytes(message);
            return udp.SendAsync(bytes, bytes.Length, ipEndPoint).AwaitResult();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReceiveString(this UdpClient udp) => DefaultEncoding.GetString(udp.ReceiveAsync().AwaitResult().Buffer);
    }
}
