using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ActorBrain", menuName = "Level Designer ToolBox/ActorBrain", order = 0)]
    public abstract class ActorBrain : ScriptableObject {
        public SmartActors thinker;

        public virtual void Init(SmartActors _thinker) {
            thinker = _thinker;
        }
        public abstract void Think(SmartActors thinker);
        private void OnDestroy() {
            thinker = null;
        }
    }
}
