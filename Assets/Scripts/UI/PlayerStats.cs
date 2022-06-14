using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RaraGames
{
    public class PlayerStats : MonoBehaviour {
        string coinsString = "Coins: ";
        [SerializeField]
        TextMeshProUGUI coinsCollectedText;
        [SerializeField]
        List<Image> healthSprites;

        private void Awake() {
            UICallBacks.onCoinCollected += OnCoinCollected;
            UICallBacks.onHealthDown += onHealthDown;
        }

        void OnCoinCollected(int coins) {
            coinsCollectedText.text = coinsString + coins.ToString();
        }

        void onHealthDown(float health) {
            // Could be better
            if (health <= 75 && health > 50) {
                healthSprites[0].enabled = false;
                healthSprites[1].enabled = true;
                healthSprites[2].enabled = true;
            }
            else if (health <= 50 && health > 0) {
                healthSprites[0].enabled = false;
                healthSprites[1].enabled = false;
                healthSprites[2].enabled = true;
            }
            else if (health <= 0) {
                healthSprites[0].enabled = false;
                healthSprites[1].enabled = false;
                healthSprites[2].enabled = false;
            } else {
                healthSprites[0].enabled = true;
                healthSprites[1].enabled = true;
                healthSprites[2].enabled = true;
            }
        }


        private void OnDestroy() {
            UICallBacks.onCoinCollected -= OnCoinCollected;
            UICallBacks.onHealthDown -= onHealthDown;
        }
    }
}