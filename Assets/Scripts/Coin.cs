using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RaraGames
{
    public class Coin : MonoBehaviour
    {
        static int coinsCollected = 0;
        private void OnTriggerEnter2D(Collider2D other) {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Player") {
                coinsCollected++;
                UICallBacks.onCoinCollected(coinsCollected);
            }
        }
    }    
}
