using UnityEngine;

namespace RaraGames
{
    [CreateAssetMenu(fileName = "TurretBrain", menuName = "Level Designer ToolBox/TurretBrain", order = 0)]

    public class TurretBrain : ActorBrain
    {
        public Projectile projectTile;

        public float shootDelay = 1f;
        private float timeSinceLastShot = 0f;

        public override void Think(SmartActors thinker)
        {
            if (timeSinceLastShot > shootDelay)
            {
                timeSinceLastShot = 0f;
                Shoot();
            }
            else
            {
                timeSinceLastShot += Time.deltaTime;
            }
        }

        void Shoot() {
            Projectile projectile = Instantiate(projectTile, thinker.transform.position, Quaternion.identity, thinker.transform.parent);
        }
    }
}
