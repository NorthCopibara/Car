using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

namespace Client {
    sealed class MenuWorld : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        [SerializeField] private InitMenu init;
        [SerializeField] private EcsUiEmitter emmiter;
        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new CamInit())

                .Add(new CamRotate())
                .Add(new MenuUI())

                .InjectUi(emmiter)
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