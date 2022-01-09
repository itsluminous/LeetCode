// i have used separate data structure, but it can also be done with 2d array
public class Solution {
    public int EarliestFullBloom(int[] plantTime, int[] growTime) {
        var n = plantTime.Length;
        
        // save the two array in one data structure
        var data = new Data[n];
        for(var i=0; i<n; i++) data[i] = new Data(plantTime[i], growTime[i]);
        
        // sort based on growth time
        Array.Sort(data, delegate(Data d1, Data d2) { return d2.grow.CompareTo(d1.grow); });
        
        // now pick plant with max growth time and plant one by one
        int totalTime = 0, currTime = 0;
        foreach(var seed in data){
            totalTime = Math.Max(totalTime, currTime + seed.plant + seed.grow);
            currTime += seed.plant;
        }
        
        return totalTime;
    }
}

public class Data{
    public int plant;
    public int grow;
    
    public Data(int plantTime, int growTime){
        plant = plantTime;
        grow = growTime;
    }
}