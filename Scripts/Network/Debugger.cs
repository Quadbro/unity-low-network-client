namespace Game.Network {

    internal class Debugger : Game.Utils.Debugger {

        public static new void Log (object obj) {
            Game.Utils.Debugger.Log("[Network] " + obj.ToString());
        }

        public static new void Warn (object obj) {
            Game.Utils.Debugger.Log("[Network] " + obj.ToString());
        }

        public static new void Err (object obj) {
            Game.Utils.Debugger.Log("[Network] " + obj.ToString());
        }
    }
}