using Leopotam.Ecs;

namespace SpaceShips
{
    sealed class ShipInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private StaticData _staticData;
        
        public void Init () 
        {
                
        }

        private void CreateShip()
        {

        }
    }
}