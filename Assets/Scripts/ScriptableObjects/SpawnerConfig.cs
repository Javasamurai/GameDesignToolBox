using UnityEngine;


namespace RaraGames
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Level Designer ToolBox/SpawnerConfig", order = 0)]
        public  class SpawnerConfig : ScriptableObject {
            public string actorName;
            public Sprite sprite;
            public int maxSpawn = 1;
            public Actor prefab;
    }
}
