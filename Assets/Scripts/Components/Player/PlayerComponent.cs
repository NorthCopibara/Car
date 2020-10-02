using UnityEngine;

enum State
{
    LEFT, IDLE, RIGHT
}

namespace Client {
    struct PlayerComponent {
        public State state;
    }
}