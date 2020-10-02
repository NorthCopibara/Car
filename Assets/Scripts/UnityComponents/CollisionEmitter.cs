using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class CollisionEmitter : MonoBehaviour
    {
        public EcsWorld world;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("EndPoint"))
            {
                ref var ent = ref world.NewEntity().Get<CollisionEvent>();
                ent.obj = this.transform;
                ent.tag = other.tag;
            }

            if (other.tag.Equals("Player"))
            {
                ref var ent = ref world.NewEntity().Get<CollisionEvent>();
                ent.obj = null;
                ent.tag = other.tag;
                return;
            }

            if (other.tag.Equals("Obstacle")) 
            {
                ref var ent = ref world.NewEntity().Get<CollisionEvent>();
                ent.obj = other.transform;
                ent.tag = other.tag;
            }
        }
    }
}
