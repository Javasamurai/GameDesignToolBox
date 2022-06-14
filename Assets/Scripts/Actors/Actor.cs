using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaraGames
{
    public class Pickable
    {
        public enum STATE
        {
            IDLE,
            LIVING,
            DESTROYED
        }
    }
    public class Actor : MonoBehaviour
    {
        public ActorConfig actorConfig;
        public Pickable.STATE currentState = Pickable.STATE.IDLE;
        public Action<Actor> onKilled;
        // Player is live in the scene.
        public virtual void Init()
        {
            currentState = Pickable.STATE.LIVING;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other != null) {
                ValidateCollider(other.gameObject);
            }
        }

       private void OnTriggerEnter2D(Collider2D other) {
            if (other != null) {
                ValidateCollider(other.gameObject);
            }
        }

        private void ValidateCollider(GameObject collider) {
            if (currentState == Pickable.STATE.LIVING && !actorConfig.canGiveDamageByTrigger || actorConfig.damageByTrigger == 0) {
                return;
            }
            Health health = collider.transform.GetComponent<Health>();
            if (health != null && health.GetCurrentHealth() > 0) {
                health.TakeDamage(actorConfig.damageByTrigger);
            }
        }
        private void OnDestroy() {
            currentState = Pickable.STATE.DESTROYED;
            onKilled?.Invoke(this);
        }
    }
}