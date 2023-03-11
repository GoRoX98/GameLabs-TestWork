using Leopotam.Ecs;
using UnityEngine;

namespace SpaceShips 
{
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        [SerializeField] StaticData _staticData;
        [SerializeField] SceneData _sceneData;
        [SerializeField] GameUI _gameUI;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new ShipInitSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(_gameUI)
                .Init ();
        }

        void FixedUpdate () {
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