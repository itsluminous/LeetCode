class Solution {
    public List<List<Integer>> minimumAbsDifference(int[] arr) {
        Arrays.sort(arr);
        List<List<Integer>> ans = new ArrayList<>();
        var diff = Integer.MAX_VALUE;

        for(var i=1; i<arr.length; i++){
            if(arr[i] - arr[i-1] < diff){
                diff = arr[i] - arr[i-1];
                ans = new ArrayList<>();
                ans.add(Arrays.asList(arr[i-1], arr[i]));
            }
            else if(arr[i] - arr[i-1] == diff)
                ans.add(Arrays.asList(arr[i-1], arr[i]));
        }

        return ans;
    }
}