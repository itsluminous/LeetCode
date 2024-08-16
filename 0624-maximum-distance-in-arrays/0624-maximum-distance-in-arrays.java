class Solution {
    public int maxDistance(List<List<Integer>> arrays) {
        int smallest = 10001, biggest = -10001, maxDist = 0;
        for(var arr : arrays){
            maxDist = Math.max(maxDist, biggest - arr.get(0));
            maxDist = Math.max(maxDist, arr.get(arr.size() - 1) - smallest);
            smallest = Math.min(smallest, arr.get(0));
            biggest = Math.max(biggest, arr.get(arr.size() - 1));
        }

        return maxDist;
    }
}