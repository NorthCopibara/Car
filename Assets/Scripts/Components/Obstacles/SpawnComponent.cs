using System.Collections.Generic;
using UnityEngine;

namespace Client {
    struct SpawnComponent {
        public List<GameObject> obstacles;
        public Transform transform;
        public float dTime;
        public float distance;
        public float complexityDeltaTime;
        public float time;
        public float speedObstacle;
    }
}