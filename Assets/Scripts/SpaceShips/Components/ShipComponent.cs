namespace SpaceShips 
{
    struct ShipComponent 
    {
        public ShipObject ShipObject;
        public ShipStruct Ship;

        public ShipComponent(ShipObject shipObj, ShipStruct ship)
        {
            ShipObject = shipObj;
            Ship = ship;
        }
            
    }
}