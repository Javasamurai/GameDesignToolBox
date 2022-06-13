using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "ChaserBrain", menuName = "Level Designer ToolBox/ChaserBrain", order = 0)]

    public class ChaserBrain : ActorBrain
    {
        public float speed = 1f;
        public float followRadius = 3f;

        GameObject player;
        // GameObject player 
        // {
        //     get {
        //         //Finding the player
        //         if (_player != null) {
        //             return _player;
        //         }
        //         var actors = GameObject.FindObjectsOfType<Actor>();
        //         for (int i = 0; i < actors.Length; i++)
        //         {
        //             if (actors[i].actorTypes.actorLayer == "Player")
        //             {
        //                 _player = actors[i].gameObject;
        //                 break;
        //             }
        //         }
        //         return _player;
        //     }
        // }

        public override void Init(GameObject _thinker) {
            base.Init(_thinker);

            var actors = GameObject.FindObjectsOfType<Actor>();
            
            for (int i = 0; i < actors.Length; i++)
            {
                if (actors[i].actorTypes.actorLayer == "Player")
                {
                    player = actors[i].gameObject;
                    break;
                }
            }
        }
        public override void Think()
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