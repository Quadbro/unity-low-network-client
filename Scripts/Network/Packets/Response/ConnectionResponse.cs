using Game.Core;
using Game.Network.Packets.Request;
using Newtonsoft.Json.Linq;

namespace Game.Network.Packets.Response {

    public class ConnectionResponse : PacketBase {

        public ConnectionResponse () {
            type = PacketType.ConnectionResponse;
        }

        public override void Handle (JObject jPacket) {
            JObject data = (JObject) jPacket["data"];
            string uid = (string) data["uid"];
            // GameManager.network.
            GameManager.network.Send(new HandshakeRequest(uid), "udp");
        }
    }
}