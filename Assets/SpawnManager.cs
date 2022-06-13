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
        public List<ActorTypes> actorTypes; 
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
                spawner.actorTypes = actorTypes[i];
            }
        }

        public  void PickActor(Actor actor, ActorTypes actorType)
        {
            activeActor = actor;
            activeActor.actorTypes = actorType;
        }

        public void UpdateGameState(bool _playing)
        {
            playing = _playing;
            for (int i = 0; i < actorsSpawned.Count; i++)
            {
                actorsSpawned[i].actorTypes.brain.Init(actorsSpawned[i].gameObject);
            }
        }

        private void OnMouseUp() {
            if (activeActor != null) {
                Vector2 postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Actor newActor = Instantiate<Actor>(activeActor, postion, Quaternion.identity, playGround);
                newActor.gameObject.layer = LayerMask.NameToLayer(activeActor.actorTypes.actorLayer);
                newActor.gameObject.transform.GetChild(0).gameObject.layer = newActor.gameObject.layer;
                newActor.gameObject.name = activeActor.actorTypes.actorName;
                newActor.onKilled += ((actor) => {
                    // Removing actor from the list
                    actorsSpawned.Remove(actor);
                });
                actorsSpawned.Add(newActor);
                activeActor = null;
            }
        }

        private void Update() {
            if (playing) {
                for (int i = 0; i < actorsSpawned.Count; i++)
                {
                    actorsSpawned[i].actorTypes.brain.Think();
                }
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
