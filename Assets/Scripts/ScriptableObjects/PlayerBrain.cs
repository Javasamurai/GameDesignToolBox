using UnityEngine;

namespace RaraGames {
    [CreateAssetMenu(fileName = "PlayerBrain", menuName = "Level Designer ToolBox/PlayerBrain", order = 0)]
    public class PlayerBrain : ActorBrain {

        public float speed = 1f;
        public override void Think() {
            if (Input.GetAxis("Horizontal") > 0) {
                thinker.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetAxis("Horizontal") < 0) {
                thinker.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetAxis("Vertical") > 0) {
                thinker.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetAxis("Vertical") < 0) {
                thinker.transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}
