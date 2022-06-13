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

        private void OnMouseUp() {
            if (activeActor != null) {
                Vector2 postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Actor newActor = Instantiate<Actor>(activeActor, postion, Quaternion.identity, playGround);
                activeActor.actorTypes.brain.Init(newActor.gameObject);
                actorsSpawned.Add(newActor);
                activeActor = null;
            }
        }

        private void Update() {
            for (int i = 0; i < actorsSpawned.Count; i++)
            {
                actorsSpawned[i].actorTypes.brain.Think();
            }
        }

        public void RemoveAllActors() {
            foreach (Actor actor in actorsSpawned) {
                Destroy(actor.gameObject);
            }
            actorsSpawned.Clear();
        }
    }
}
