using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaraGames
{
    public class SpawnManager: MonoBehaviour
    {
        public Spawner toolItemPrefab;
        public Transform toolContainer;
        [SerializeField]
        public List<SpawnerConfig> actorTypes;
        List<Actor> actorsSpawned;
        private Actor activeActor;
        public Transform playGround;

        private bool playing = false;
        private void Awake() {
            Spawner.onSpawnActor += ( (actor, actortType) => {
                PickActor(actor, actortType);
            });
        }
        void Start()
        {
            actorsSpawned = new List<Actor>();

            for (int i = 0; i < actorTypes.Count; i++)
            {
                Spawner spawner = Instantiate<Spawner>(toolItemPrefab, Vector3.one, Quaternion.identity, toolContainer);
                spawner.spawnerConfig = actorTypes[i];
            }
        }

        public  void PickActor(Actor actor, SpawnerConfig actorType)
        {
            activeActor = actor;
        }

        public void UpdateGameState(bool _playing)
        {
            playing = _playing;
            for (int i = 0; i < actorsSpawned.Count; i++)
            {
                actorsSpawned[i].Init();
            }
        }

        private void OnMouseUp() {
            if (activeActor != null) {
                Vector2 postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Actor newActor = Instantiate<Actor>(activeActor, postion, Quaternion.identity, playGround);
                // newActor.gameObject.name = activeActor.actorConfig.actorName + actorsSpawned.Count;
                newActor.onKilled += ((actor) => {
                    // Removing actor from the list
                    actorsSpawned.Remove(actor);
                });
                actorsSpawned.Add(newActor);
                activeActor = null;
            }
        }

        private void RemoveActor(Actor actor)
        {
            actorsSpawned.Remove(actor);
        }

        public void RemoveAllActors() {
            foreach (Actor actor in actorsSpawned) {
                Destroy(actor.gameObject);
            }
            actorsSpawned.Clear();
        }
    }
}
