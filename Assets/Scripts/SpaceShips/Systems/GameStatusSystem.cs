using Leopotam.Ecs;

namespace SpaceShips 
{
    sealed class GameStatusSystem : IEcsInitSystem, IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GameUI _gameUI;
        private EcsFilter<GameStatusComponent> _gameStatus;

        public void Init () 
        {
            _gameUI.StartGame.onClick.AddListener(call: () => ChangeStatus(GameStatus.Battle));
            _gameUI.Restart.onClick.AddListener(call: () =>  ChangeStatus(GameStatus.Prepare));

            EcsEntity entity = _world.NewEntity();
            entity.Get<GameStatusComponent>() = new(GameStatus.Prepare);
        }

        public void Run ()
        {

        }

        private void ChangeStatus(GameStatus status)
        {
            _gameStatus.Get1(0).Status = status;
            EcsEntity statusEntity = _world.NewEntity();
            statusEntity.Get<ChangeStatusComponent>();
        }
    }
}