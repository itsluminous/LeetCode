class Solution {
    List<Integer> ans = new ArrayList<>();

    public int[] findEvenNumbers(int[] digits) {
        var freq = new int[10];
        for(var digit : digits) freq[digit]++;

        // one by one, fill digits at each pos
        for(var d1=1; d1<10; d1++){
            if(freq[d1] == 0) continue;
            freq[d1]--;
            fillOthers(freq, d1);
            freq[d1]++;
        }

        return ans.stream().mapToInt(Integer::intValue).toArray();
    }

    private void fillOthers(int[] freq, int d1){
        for(var d2=0; d2<10; d2++){
            if(freq[d2] == 0) continue;
            freq[d2]--;
            fillLast(freq, d1, d2);
            freq[d2]++;
        }
    }

    private void fillLast(int[] freq, int d1, int d2){
        for(var d3=0; d3<10; d3+=2){
            if(freq[d3] == 0) continue;
            var num = d1 * 100 + d2 * 10 + d3;
            ans.add(num);
        }
    }
}