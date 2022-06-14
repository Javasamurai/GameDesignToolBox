using UnityEngine;

namespace RaraGames {
    [CreateAssetMenu(fileName = "PlayerBrain", menuName = "Level Designer ToolBox/PlayerBrain", order = 0)]
    public class PlayerBrain : ActorBrain {
        public float speed = 1f;
        public LayerMask blockMask;
        public override void Think(SmartActors thinker) {
            Vector3 targetPosition = Vector2.zero;
            if (Input.GetAxis("Horizontal") > 0) {
                targetPosition = Vector3.right;
            }
            if (Input.GetAxis("Horizontal") < 0) {
                targetPosition = Vector3.left;
            }
            if (Input.GetAxis("Vertical") > 0) {
                targetPosition = Vector3.up;
            }
            if (Input.GetAxis("Vertical") < 0) {
                targetPosition = Vector3.down;
            }


            if (targetPosition != Vector3.zero) {  
                RaycastHit2D hit = Physics2D.Raycast(thinker.transform.position, targetPosition.normalized, speed * Time.deltaTime, blockMask);              
                Debug.DrawRay(thinker.transform.position, targetPosition.normalized * speed * Time.deltaTime, Color.green);
                if (hit.collider != null) {
                    targetPosition = Vector3.zero;
                } else {
                    thinker.transform.position += targetPosition * speed * Time.deltaTime;
                }
            }
        }
    }
}
