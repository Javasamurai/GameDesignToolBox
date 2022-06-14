using System;
using System.Collections.Generic;
using UnityEngine;

namespace RaraGames
{

    // Smart actors have brains to act on
    public class SmartActors : Actor
    {
        public Health health;
        public ActorBrain brain;
        public override void Init()
        {
            base.Init();
            health.Init(actorConfig.maxHealth);
            brain.Init(this);
        }

        // Can have multiple brains as well, to make it more interesting.
        // public List<ActorBrain> brains;

        private void Update() {
            if (currentState == Pickable.STATE.LIVING) {
                brain.Think(this);
            }
        }
    }
}
