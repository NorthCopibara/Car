using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using UnityEngine.UIElements;

namespace Client {
    sealed class CarWorld : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        InitWorld init;
        public EcsUiEmitter emitter;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.

            init = GetComponent<InitWorld>();

            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new GUI())
                .Add(new RecordInit())

                .Add(new ParalacsInit())
                .Add(new PlayerInit())
                .Add(new SpawnInit())
                .Add(new GUIInit())

                .Add(new ObstacleMove())
                .Add(new Spawn())
                .Add(new InputSystem())
                .Add(new Player())
                .Add(new PlayerPosition())
                .Add(new DestroyObstacle())
                .Add(new Record())

                .Add(new Paralacs())
                .Add(new EndGameSystem())
                .OneFrame<StateSwichEvent>()
                .OneFrame<CollisionEvent>()

                
                .InjectUi(emitter)
                .Inject(init)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}