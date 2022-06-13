using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "WandererBrain", menuName = "Level Designer ToolBox/WandererBrain", order = 0)]

    public class WandererBrain : ActorBrain {
        public float radius = 5;

        public float speed = 1;
        
        private Vector3 currentPosition;
        private Vector3 desiredPosition;

        private DIRECTION currentDirection = DIRECTION.LEFT;

        private enum DIRECTION {
            LEFT,
            RIGHT
        }
        public override void Init(GameObject _thinker) {
            base.Init(_thinker);
            currentPosition = thinker.transform.localPosition;
            desiredPosition = thinker.transform.localPosition + Vector3.left * radius;
        }
        public override void Think() {
            if (thinker.transform.position.x <= desiredPosition.x && currentDirection == DIRECTION.LEFT) {
                currentDirection = DIRECTION.RIGHT;
                desiredPosition = thinker.transform.localPosition + Vector3.right * radius;
            }
            if (thinker.transform.position.x >= desiredPosition.x && currentDirection == DIRECTION.RIGHT) {
                currentDirection = DIRECTION.LEFT;
                desiredPosition = thinker.transform.localPosition + Vector3.left * radius;
            }

            Vector3 nextPosition;
            if (currentDirection == DIRECTION.LEFT) {
                nextPosition = thinker.transform.localPosition + Vector3.left * radius;
            } else {
                nextPosition = thinker.transform.localPosition + Vector3.right * radius;
            }
            thinker.transform.localPosition = Vector3.MoveTowards(thinker.transform.localPosition, nextPosition, speed * Time.deltaTime);
        }
    }
}
