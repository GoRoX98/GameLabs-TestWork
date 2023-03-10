using Leopotam.Ecs;
using UnityEngine;

namespace SpaceShips
{
    public class ShipFabric
    {
        private EcsWorld _world;
        private StaticData _staticData;
        private SceneData _sceneData;
        private int _shipId;

        public ShipFabric(EcsWorld world, StaticData staticData, SceneData sceneData)
        {
            _world = world;
            _staticData = staticData;
            _sceneData = sceneData;
        }

        public void CreateShip()
        {
            EcsEntity shipEntity = _world.NewEntity();
            _shipId = shipEntity.GetInternalId();
            shipEntity.Get<ShipComponent>() = new(_sceneData.ShipsObject[_shipId], _staticData.Ships[_shipId].Ship);

            CreateModules();
            CreateWeapons();
        }

        private void CreateWeapons()
        {
            EcsEntity weaponEntity = _world.NewEntity();
            weaponEntity.Get<OwnerComponent>() = new(_shipId);

        }

        private void CreateModules()
        {
            EcsEntity moduleEntity = _world.NewEntity();
            moduleEntity.Get<OwnerComponent>() = new(_shipId);
        }
    }
}
