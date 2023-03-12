namespace Metro
{
    public struct Path
    {
        public int Steps;
        public int TransferCount;

        public Path(int steps, int transfers)
        {
            Steps = steps;
            TransferCount = transfers;
        }
    }
}