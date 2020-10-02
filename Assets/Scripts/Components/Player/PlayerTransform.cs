using UnityEngine;

namespace Client {
    struct PlayerTransform {
        public Transform transform;
        public State state;
        public Vector3 newPos;
    }
}