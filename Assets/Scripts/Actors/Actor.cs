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
        public Action<Actor> onKilled;
        public float health = 100f;
        public ActorTypes _actorTypes;
        public Pickable.STATE currentState = Pickable.STATE.IDLE;
        public ActorTypes actorTypes {
            set {
                _actorTypes = value;
                this.health = value.maxHealth;
            }
            get {
                return _actorTypes;
            }
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                currentState = Pickable.STATE.DESTROYED;
                onKilled?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public void GiveDamage(Actor actor) 
        {
            if (actor != null) {
                actor.TakeDamage(this.actorTypes.damageByTrigger);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!actorTypes.canGiveDamageByTrigger) {
                return;
            }
            GiveDamage(other.gameObject.GetComponent<Actor>());
        }
    }
}