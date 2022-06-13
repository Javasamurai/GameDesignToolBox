using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaraGames
{
    public class Pickable
    {
        public enum STATE
        {
            UNPICKED,
            PICKED,
            CANCELLED,
            PICKED_AND_DROPPED
        }
    }
    public class Actor : MonoBehaviour
    {
        public Pickable.STATE currentState = Pickable.STATE.UNPICKED;
        public ActorTypes actorTypes;
    }
}