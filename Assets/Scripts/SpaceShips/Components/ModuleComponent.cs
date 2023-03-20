namespace SpaceShips 
{
    public struct ModuleComponent 
    {
        public string ModuleName;
        public ModuleStruct Module;

        public ModuleComponent(ModuleStruct module, string name)
        {
            Module = module;
            ModuleName = name;
        }
    }
}