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
            if ( (1 << other.gameObject.layer) == damageLayer.value && other.transform.parent.GetComponent<Actor>() != null) {
                other.transform.parent.GetComponent<Actor>().TakeDamage(config.damage);
                SelfDestruct();
            }
        }
        void SelfDestruct() {
            Destroy(gameObject);
        }

    }    
}
