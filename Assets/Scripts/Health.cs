using UnityEngine;

namespace RaraGames
{
    using UnityEngine;    
    public class Health : MonoBehaviour {
        public float currentHealth = 100;
        private bool isPlayer; 
        public void Init(float health, bool _isPlayer) {
            currentHealth = 100;
            isPlayer = _isPlayer;
        }

        public void TakeDamage(float damage) {
            currentHealth -= damage;
            if (isPlayer) {
                UICallBacks.onHealthDown(currentHealth);
            }
            if (currentHealth <= 0) {
                currentHealth = 0;
                Destroy(gameObject);
            }
        }

        public float GetCurrentHealth() {
            return currentHealth;
        }

        // Not used yet.
        public void Heal(float healAmount) {
            currentHealth += healAmount;
        }
    }
}