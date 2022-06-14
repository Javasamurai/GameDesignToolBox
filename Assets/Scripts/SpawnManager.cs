using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        void Start()
        {
            actorsSpawned = new List<Actor>();

            for (int i = 0; i < actorTypes.Count; i++)
            {
                Spawner spawner = Instantiate<Spawner>(toolItemPrefab, Vector3.one, Quaternion.identity, toolContainer);
                spawner.spawnerConfig = actorTypes[i];

                spawner.onSpawnActor += ( (actor, actorType) => {
                    PickActor(actor, actorType);
                });
            }
        }

        public  void PickActor(Actor actor, SpawnerConfig actorType)
        {
            activeActor = actor;

            for (int i = 0; i < toolContainer.transform.childCount; i++)
            {
                toolContainer.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }

        public void UpdateGameState(bool _playing)
        {
            playing = _playing;
            toolContainer.gameObject.SetActive(!playing);
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
                Actor.onKilled += ((actor, isPlayer) => {
                    // Removing actor from the list
                    actorsSpawned.Remove(actor);
                });

                for (int i = 0; i < toolContainer.transform.childCount; i++)
                {
                    toolContainer.GetChild(i).GetComponent<Button>().interactable = true;
                }
                actorsSpawned.Add(newActor);
                activeActor = null;
            }
        }

        private void RemoveActor(Actor actor)
        {
            actorsSpawned.Remove(actor);
        }

        public void DeactivateAllActors()
        {
            for (int i = 0; i < actorsSpawned.Count; i++)
            {
                actorsSpawned[i].Deactivate();
            }
        }

        public void RemoveAllActors() {
            foreach (Actor actor in actorsSpawned) {
                actor.DeInit();
            }
            actorsSpawned.Clear();
        }
    }
}
