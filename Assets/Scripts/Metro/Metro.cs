using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    public class Metro : MonoBehaviour
    {
        [SerializeField] private List<LineSO> _lines;
        [SerializeField] private MetroUI _ui;
        private StationSO _startPoint;
        private StationSO _endPoint;

        private void Awake()
        {
            _ui.Calculate.onClick.AddListener(call: () => Calculate());
        }

        private void Calculate()
        {
            _startPoint = _ui.StationsUI.StartStationSO;
            _endPoint = _ui.StationsUI.EndStationSO;

            if (_startPoint == _endPoint)
            {
                List<StationSO> pathStory = new();
                pathStory.Add(_startPoint);
                _ui.Result(new Path(0, 0, pathStory));
                return;
            }

            List<LineSO> startLines = new();
            foreach (LineSO line in _lines)
            {
                if (line.Stations.Find(match => match == _startPoint))
                    startLines.Add(line);
            }

            Path path = FindWay(startLines);

            _ui.Result(path);
        }

        private Path FindWay(List<LineSO> startLines)
        {
            Path path = new();
            bool findWay = false;
            int step = 0;

            List<WayStruct> ways = new();

            CreateNewWays(startLines, _startPoint, 0, ref ways);

            while (!findWay)
            {
                List<WayStruct> newWays = new();

                for (int i = 0; i < ways.Count; i++)
                {
                    if (ways[i].WayEnd)
                        continue;

                    ways[i] = NextStation(ways[i]);
                    ways[i].PathStory.Add(ways[i].CurrentStation);


                    if(ways[i].CurrentStation == _endPoint)
                    {
                        findWay = true;
                        path = new(step, ways[i].TransferCount, ways[i].PathStory);
                        break;
                    }

                    if (ways[i].WayEnd)
                        continue;

                    List<LineSO> newLines = FindTransfer(ways[i]);
                    if (newLines != null)
                        CreateNewWays(newLines, ways[i].CurrentStation, ways[i].TransferCount + 1, ref newWays, ways[i]);
                }

                step += 1;

                if (newWays != null)
                    ways.AddRange(newWays);
            }

            return path;
        }

        private void CreateNewWays(List<LineSO> lines, StationSO station, int transfer, ref List<WayStruct> ways, WayStruct way = new())
        {
            foreach (var line in lines)
            {
                ways.Add(new WayStruct(line, station, transfer, way.PathStory));
                if (line.RingLine || line.Stations.IndexOf(station) > 0)
                    ways.Add(new WayStruct(line, station, transfer, way.PathStory, true));
            }
        }

        private List<LineSO> FindTransfer(WayStruct way)
        {
            List<LineSO> newLines = _lines.FindAll(match => match.Stations.Find(match => match == way.CurrentStation) && match != way.Line);
            return newLines;
        }

        private WayStruct NextStation(WayStruct way)
        {
            if(way.ReverseWay)
            {
                if (way.Line.Stations.IndexOf(way.CurrentStation) == 0 && way.Line.RingLine)
                    way.CurrentStation = way.Line.Stations[way.Line.Stations.Count - 1];
                else if (way.Line.Stations.IndexOf(way.CurrentStation) == 0)
                    way.WayEnd = true;
                else
                    way.CurrentStation = way.Line.Stations[way.Line.Stations.IndexOf(way.CurrentStation) - 1];
            }
            else
            {
                if (way.Line.Stations.IndexOf(way.CurrentStation) == way.Line.Stations.Count - 1 && way.Line.RingLine)
                    way.CurrentStation = way.Line.Stations[0];
                else if (way.Line.Stations.IndexOf(way.CurrentStation) == way.Line.Stations.Count - 1)
                    way.WayEnd = true;
                else
                    way.CurrentStation = way.Line.Stations[way.Line.Stations.IndexOf(way.CurrentStation) + 1];
            }

            if (way.CurrentStation == way.StartStation)
            {
                way.WayEnd = true;
            }

            return way;
        }

    }
}
