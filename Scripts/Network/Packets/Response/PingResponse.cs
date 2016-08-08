using Game.Core;
using Game.Network.Packets.Request;
using Newtonsoft.Json.Linq;

namespace Game.Network.Packets.Response {

    public class PingResponse : PacketBase {

        public PingResponse () {
            type = PacketType.PingResponse;
        }

        public override void Handle (JObject jPacket) {
            JObject data = (JObject) jPacket["data"];
            long timestamp = (long) data["timestamp"];
            int ping = (int) data["ping"];
            GameManager.network.ping = ping;
            GameManager.network.Send(new PingRequest(timestamp));
        }
    }
}