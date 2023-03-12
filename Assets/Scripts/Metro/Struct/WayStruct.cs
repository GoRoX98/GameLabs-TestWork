namespace Metro
{
    public struct WayStruct
    {
        public int TransferCount;
        public bool WayEnd;
        public LineSO Line;
        public StationSO CurrentStation;
        public StationSO StartStation;
        public bool ReverseWay;

        public WayStruct(LineSO line, StationSO station, int transfers, bool reverse = false)
        {
            TransferCount = transfers;
            WayEnd = false;
            Line = line;
            CurrentStation = station;
            StartStation = station;
            ReverseWay = reverse;
        }
    }
}