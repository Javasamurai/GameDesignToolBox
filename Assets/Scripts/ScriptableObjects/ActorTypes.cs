using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ActorTypes", menuName = "Level Designer ToolBox/ActorTypes", order = 0)]
    public class ActorTypes : ScriptableObject {
        // Name of the item in the scene.
        public string actorName;
        public Sprite sprite;
        public int maxSpawn = 1;

        public ActorBrain brain;
    }
}
