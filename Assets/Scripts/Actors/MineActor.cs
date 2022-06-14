using UnityEngine;

namespace RaraGames
{
    public class MineActor : Actor {
        public ParticleSystem particleEffect;
        public override void ValidateCollider(GameObject collider) {
            base.ValidateCollider(collider);
            particleEffect.Play();
        }
    }
}
