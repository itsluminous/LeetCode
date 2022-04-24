// dict<string, dict<string,int>>()  for stn to stn how much time a
public class UndergroundSystem {
    private readonly IDictionary<int, (string station, int t)> _currentCheckins;
    private readonly IDictionary<string, (int sum, int count)> _travels;
    
    public UndergroundSystem() {
        _currentCheckins = new Dictionary<int, (string station, int t)>();
        _travels = new Dictionary<string, (int sum, int count)>();
    }
    
    public void CheckIn(int id, string stationName, int t) {
        _currentCheckins[id] = (stationName, t);
    }
    
    public void CheckOut(int id, string stationName, int t) {
        var checkin = _currentCheckins[id];
        _currentCheckins.Remove(id);

        var key = $"{checkin.station}->{stationName}";
        if (!_travels.ContainsKey(key)) _travels[key] = (0,0);
        _travels[key] = (_travels[key].sum + t - checkin.t, _travels[key].count + 1);
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        var key = $"{startStation}->{endStation}";
        if (!_travels.ContainsKey(key)) return 0;

        return (double) _travels[key].sum / _travels[key].count;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */