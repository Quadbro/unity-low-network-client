using System.Collections.Generic;
using Game.Utils.Vector3;

namespace Game.Map.Data {

    public class M_Object {
        public string name { get; set; }
        public string package { get; set; }
        public string state { get; set; }
        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }
        public Vector3 scale { get; set; }
        public List<M_Collider> colliders { get; set; }

        public M_Object () {
            this.name = "null";
            this.package = "null";
            this.state = "null";
            this.pos = new Vector3(0, 0, 0);
            this.rot = new Vector3(0, 0, 0);
            this.scale = new Vector3(0, 0, 0);
            this.colliders = new List<M_Collider>();
        }

        public M_Object (M_Object obj) {
            this.name = obj.name;
            this.package = obj.package;
            this.state = obj.state;
            this.pos = obj.pos;
            this.rot = obj.rot;
            this.scale = obj.scale;
            this.colliders = obj.colliders;
        }
    }
}