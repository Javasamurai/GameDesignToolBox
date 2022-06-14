using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ChaserBrain", menuName = "Level Designer ToolBox/ChaserBrain", order = 0)]

    public class ChaserBrain : ActorBrain
    {
        public float speed = 1f;
        public float followRadius = 3f;

        GameObject player;

        public override void Init(SmartActors thinker) {
            base.Init(thinker);
            var actors = GameObject.FindObjectsOfType<SmartActors>();
            
            for (int i = 0; i < actors.Length; i++)
            {
                if (actors[i].actorConfig.isPlayer)
                {
                    player = actors[i].gameObject;
                    break;
                }
            } 
        }

        public override void Think(SmartActors thinker)
        {
            if (player == null)
            {
                Debug.LogError("Player not found to chase");
                return;
            }
            Vector2 distance = player.transform.position - thinker.transform.position;

            if (distance.magnitude > followRadius)
            {
                thinker.transform.position = Vector2.MoveTowards(thinker.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}