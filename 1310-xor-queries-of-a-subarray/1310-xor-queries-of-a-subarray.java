class Solution {
    public int[] xorQueries(int[] arr, int[][] queries) {
        int n = arr.length, q = queries.length;
        int[] prefixXor = new int[n], answer = new int[q];
        
        prefixXor[0] = arr[0];
        for(var i=1; i<n; i++)
            prefixXor[i] = prefixXor[i-1] ^  arr[i];
        
        for(var i=0; i<q; i++){
            int start = queries[i][0], end = queries[i][1];
            if(start == 0)
                answer[i] = prefixXor[end];
            else 
                answer[i] = prefixXor[end] ^ prefixXor[start-1];
        }

        return answer;
    }
}