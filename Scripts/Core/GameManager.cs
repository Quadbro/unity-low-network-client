using Game.Core.EventManager;
using Game.Network;
using Game.Utils;

namespace Game.Core {

    public class GameManager : Singleton<GameManager> {
        private NetworkHandler _network;
        private EventHandler _events;

        public static NetworkHandler network {
            get { return instance._network; }
            private set { }
        }

        public static EventHandler events {
            get { return instance._events; }
            private set { }
        }

        public void Awake () {
            this._network = new NetworkHandler();
            this._events = new EventHandler();
        }

        public void OnApplicationQuit () {
            this._network.Disconnect();
        }
    }
}