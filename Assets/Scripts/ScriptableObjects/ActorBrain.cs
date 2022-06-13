using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ActorBrain", menuName = "Level Designer ToolBox/ActorBrain", order = 0)]
    public abstract class ActorBrain : ScriptableObject {
        public GameObject thinker;
        public virtual void Init(GameObject _thinker) {
            thinker = _thinker;
        }
        public abstract void Think();
        private void OnDestroy() {
            thinker = null;
        }
    }
}
