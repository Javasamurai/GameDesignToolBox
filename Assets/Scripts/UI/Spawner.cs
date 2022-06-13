using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RaraGames {
    public class Spawner : MonoBehaviour
    {
        public Image background;
        public TextMeshProUGUI actorName;

        private ActorTypes _actorTypes;

        public ActorTypes actorTypes {
            get {
                return _actorTypes;
            }
            set {
                if (value != null) {
                    _actorTypes = value;
                    background.sprite = _actorTypes.sprite;
                    actorName.text = _actorTypes.actorName;
                    maxSpawn = _actorTypes.maxSpawn;
                }
            }
        }

        private int maxSpawn = 10;
        private int currentSpawn = 0;
        public Actor actorPrefab;
        private Button button;
        public static event onSpawnActorEvent onSpawnActor;
        public delegate void onSpawnActorEvent(Actor actor, ActorTypes actorType);
        
        private void Awake() {
            button = GetComponent<Button>();
            
            button.onClick.AddListener( () => {
                currentSpawn++;
                onSpawnActor(actorPrefab, actorTypes);
                if (currentSpawn >= maxSpawn) {
                    // Disable button if max spawn is reached
                    button.interactable = false;
                    return;
                }
            });
        }
    }
}
