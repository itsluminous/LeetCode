public class RandomizedSet {
    Dictionary<int,bool> dict;
    Random rnd;

    public RandomizedSet() {
        dict = new Dictionary<int,bool>();
        rnd = new Random();
    }
    
    public bool Insert(int val) {
        if(dict.ContainsKey(val)) return false;
        dict[val] = true;
        return true;
    }
    
    public bool Remove(int val) {
        if(!dict.ContainsKey(val)) return false;
        dict.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        var idx = rnd.Next(0,dict.Keys.Count);
        return dict.ElementAt(idx).Key;
    }
}