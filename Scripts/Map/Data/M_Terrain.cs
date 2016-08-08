using Game.Utils.Vector3;
using Newtonsoft.Json.Linq;

namespace Game.Map.Data {

    public class M_Terrain {
        public string name { get; set; }
        public Vector3 pos { get; set; }
        public Vector3 scale { get; set; }
        public float[,] heights { get; set; }

        public M_Terrain () {
            this.name = "null";
            this.pos = new Vector3(0, 0, 0);
            this.scale = new Vector3(0, 0, 0);
            this.heights = null;
        }

        public M_Terrain (UnityEngine.Terrain t) {
            this.scale = Vector3.ConvertFromUE(t.terrainData.size);
            this.heights = t.terrainData.GetHeights(0, 0, (int) scale.X, (int) scale.Z);
            this.name = t.name;
            this.pos = Vector3.ConvertFromUE(t.GetPosition());
            this.scale = Vector3.ConvertFromUE(t.terrainData.size);
        }

        public static float[,] GetHeightsFromJArray (JArray array) {
            int sizeX = array.Count;
            int sizeY = ((JArray) array[0]).Count;

            float[,] resultArray = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++) {
                JArray jArr = (JArray) array[i];
                for (int j = 0; j < sizeY; j++) {
                    resultArray[i, j] = (float) jArr[j];
                }
            }
            return resultArray;
        }
    }
}