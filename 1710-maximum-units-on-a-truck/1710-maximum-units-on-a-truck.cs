public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        var sorted = boxTypes.OrderByDescending(b => b[1]);
        var maxunits = 0;
        foreach(var box in sorted){
            if(truckSize <= box[0]){
                maxunits += truckSize * box[1];
                break;
            }
            maxunits += box[0] * box[1];
            truckSize -= box[0];
        }
        
        return maxunits;
    }
}