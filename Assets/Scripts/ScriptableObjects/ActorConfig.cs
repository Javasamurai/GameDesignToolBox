using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ActorConfig", menuName = "Level Designer ToolBox/ActorConfig", order = 0)]
    public class ActorConfig : ScriptableObject {
        public bool isPlayer = false;
        public float maxHealth = 100f;
        public bool canGiveDamageByTrigger = false;
        public float damageByTrigger = 10f;
        public bool canDestoyByTrigger = false;
    }
}
