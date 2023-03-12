namespace SpaceShips
{
    struct GameStatusComponent 
    {
        public GameStatus Status;

        public GameStatusComponent(GameStatus status)
        {
            Status = status;
        }
    }
}