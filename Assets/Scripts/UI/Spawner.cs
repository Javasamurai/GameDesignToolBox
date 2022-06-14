using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RaraGames {
    public class Spawner : MonoBehaviour
    {
        public Image background;
        public TextMeshProUGUI actorName;

        private SpawnerConfig _spawnerConfig;

        public SpawnerConfig spawnerConfig {
            get {
                return _spawnerConfig;
            }
            set {
                if (value != null) {
                    _spawnerConfig = value;
                    background.sprite = _spawnerConfig.sprite;
                    actorName.text = _spawnerConfig.actorName;
                    maxSpawn = _spawnerConfig.maxSpawn;
                }
            }
        }

        private int maxSpawn = 10;
        private int currentSpawn = 0;
        private Button button;
        public event onSpawnActorEvent onSpawnActor;
        public delegate void onSpawnActorEvent(Actor actor, SpawnerConfig spawner);
        
        private void Awake() {
            button = GetComponent<Button>();
            
            button.onClick.AddListener( () => {
                currentSpawn++;
                onSpawnActor(spawnerConfig.prefab, spawnerConfig);
                if (currentSpawn >= maxSpawn) {
                    // Disable button if max spawn is reached
                    Destroy(gameObject);
                    return;
                }
            });
        }
    }
}
