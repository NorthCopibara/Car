using Leopotam.Ecs;
using System.Xml;
using UnityEngine;

namespace Client {
    sealed class CamRotate : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<CamComponent> cam = null;
        
        void IEcsRunSystem.Run () {
            foreach (var i in cam) 
            {
                Transform t = cam.Get1(i).camTransform;
                t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y - 0.5f, t.eulerAngles.z);
            }
        }
    }
}