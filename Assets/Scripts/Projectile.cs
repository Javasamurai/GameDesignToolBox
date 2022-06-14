using UnityEngine;

namespace RaraGames
{
    public class Projectile : MonoBehaviour {
        public ProjectileConfig config;

        public LayerMask damageLayer;

        private void Start() {
            Invoke("SelfDestruct", config.lifetime);
        }

        private void Update() {
            transform.Translate(Vector3.left * config.speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if ( (damageLayer.value & 1 << other.gameObject.layer) > 0) {
                if (other.transform.GetComponent<Health>() != null) {
                    other.transform.GetComponent<Health>().TakeDamage(config.damage);
                }
                SelfDestruct();
            }
        }
        void SelfDestruct() {
            Destroy(gameObject);
        }
    }    
}
