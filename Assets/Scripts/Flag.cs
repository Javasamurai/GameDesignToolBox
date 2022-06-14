using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RaraGames
{
    public class Flag : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Player") {
                UICallBacks.onFlagCollected();
            }
        }
    }    
}
