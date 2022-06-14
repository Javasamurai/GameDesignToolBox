using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "WandererBrain", menuName = "Level Designer ToolBox/WandererBrain", order = 0)]

    public class WandererBrain : ActorBrain {
        public float radius = 5;
        public float speed = 1;
        public float damage = 100;
        private Vector3 desiredPosition;

        private DIRECTION currentDirection = DIRECTION.LEFT;

        public LayerMask blockMask;
        private enum DIRECTION {
            LEFT,
            RIGHT
        }
        public override void Think(SmartActors thinker) {
            RaycastHit2D hit = Physics2D.Raycast(thinker.transform.position, currentDirection == DIRECTION.LEFT ? Vector2.left : Vector2.right, speed * Time.deltaTime, blockMask);
            bool gotHit = hit.collider != null;

            if ( (thinker.transform.position.x <= desiredPosition.x || gotHit) && currentDirection == DIRECTION.LEFT) {
                currentDirection = DIRECTION.RIGHT;
                desiredPosition = thinker.transform.localPosition + Vector3.right * radius;
            }
            else if ((thinker.transform.position.x >= desiredPosition.x || gotHit) && currentDirection == DIRECTION.RIGHT) {
                currentDirection = DIRECTION.LEFT;
                desiredPosition = thinker.transform.localPosition + Vector3.left * radius;
            }

            Vector3 nextPosition;
            Vector3 targetPosition = Vector3.zero;
            if (currentDirection == DIRECTION.LEFT) {
                targetPosition = Vector3.left;
            } else {
                targetPosition = Vector3.right;
            }
            nextPosition = thinker.transform.localPosition + targetPosition * radius;
            thinker.transform.localPosition = Vector3.MoveTowards(thinker.transform.localPosition, nextPosition, speed * Time.deltaTime);
        }
    }
}
