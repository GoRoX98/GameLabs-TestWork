using System.Collections.Generic;

namespace Metro
{
    public struct WayStruct
    {
        public int TransferCount;
        public bool WayEnd;
        public LineSO Line;
        public StationSO CurrentStation;
        public StationSO StartStation;
        public List<StationSO> PathStory;
        public bool ReverseWay;

        public WayStruct(LineSO line, StationSO station, int transfers, List<StationSO> story = null, bool reverse = false)
        {
            TransferCount = transfers;
            WayEnd = false;
            Line = line;
            CurrentStation = station;
            StartStation = station;

            PathStory = new();
            if (story == null)
                PathStory.Add(station);
            else
                PathStory.AddRange(story);

            ReverseWay = reverse;
        }
    }
}