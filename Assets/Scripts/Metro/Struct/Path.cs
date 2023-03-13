using System.Collections.Generic;

namespace Metro
{
    public struct Path
    {
        public int Steps;
        public int TransferCount;
        public List<StationSO> PathStory;

        public Path(int steps, int transfers, List<StationSO> path)
        {
            Steps = steps;
            TransferCount = transfers;
            PathStory = path;
        }
    }
}