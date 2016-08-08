using Game.Network.Packets;
using Game.Utils;
using UnityEngine;

public class _TestScript : MonoBehaviour {

    private void Start () {
        PacketHandler ph = new PacketHandler();

        // string jsonResponse1 = new ConnectionRequest("Quadbro", "1234").Encode();
        string s = "{ \"id\":2,\"data\":{\"username\":\"Quadbro\",\"password\":\"1234\"} }";

        Debugger.Log("trying to resieve: " + s);
        ph.HandleRawPacket(s);

        //string jsonResponse2 = new MapResponse().Encode();
        s = "{ \"id\":4,\"data\":{\"Object1\":\"_ground\",\"Object2\":\"_grass\"} }";
        Debugger.Log("trying to resieve: " + s);
        ph.HandleRawPacket(s);
    }

    private void Update () {
    }
}