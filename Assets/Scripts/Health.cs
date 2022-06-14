using UnityEngine;

namespace RaraGames
{
    using UnityEngine;    
    public class Health : MonoBehaviour {
        public float currentHealth = 100;
        public void Init(float health) {
            currentHealth = 100;
        }

        public void TakeDamage(float damage) {
            currentHealth -= damage;
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