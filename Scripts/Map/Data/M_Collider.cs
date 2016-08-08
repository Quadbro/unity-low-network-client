using Game.Utils.Vector3;

namespace Game.Map.Data {

    public class M_Collider {
        public string type { get; set; }
        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }
        public Vector3 size { get; set; }

        public M_Collider () {
            this.type = "null";
            this.pos = new Vector3(0, 0, 0);
            this.rot = new Vector3(0, 0, 0);
            this.size = new Vector3(0, 0, 0);
        }
    }
}