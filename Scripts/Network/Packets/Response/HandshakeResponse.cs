﻿using Newtonsoft.Json.Linq;

namespace Game.Network.Packets.Response {

    public class HandshakeResponse : PacketBase {

        public HandshakeResponse () {
            type = PacketType.HandshakeResponse;
        }

        public override void Handle (JObject jPacket) {
            JObject data = (JObject) jPacket["data"];
            string msg = (string) data["msg"];
            switch (msg) {
                case "ok":
                    Debugger.Log("Udp handshake established");
                    break;

                default:
                    Debugger.Err("Udp handshake hasn't been established!");
                    break;
            }
        }
    }
}