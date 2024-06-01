// a = xor of i to j-1
// b = xor of j to k
// if a == b, then a ^ b == b ^ b
// i.e.  a ^ b = 0
// thus,  arr[i] ^ arr[i + 1] ^ ... ^ arr[j - 1] ^ arr[j] ^ arr[j + 1] ^ ... ^ arr[k] = 0
// now this is a prefix problem. We need to find out how many times we have seen a particular xor value

// Complexity : O(n^2)
class Solution {
    public int CountTriplets(int[] arr) {
        var n = arr.Length;
        var count = 0;

        for(var left=0; left<n; left++){
            var currXor = arr[left];
            for(var right = left + 1; right<n; right++){
                currXor ^= arr[right];
                if(currXor == 0)
                    count += (right-left);
            }
        }

        return count;
    }
}

// Complexity : O(n)
class SolutionBetter {
    public int CountTriplets(int[] arr) {
        var n = arr.Length;
        Dictionary<int, int> countOfCumulativeXor = new (), 
                              subArrWithCumulativeXor = new ();

        // one possibility to get 0 xor is not have any num inculded
        countOfCumulativeXor[0] = 1;
        subArrWithCumulativeXor[0] = -1;

        int prefixXor = 0, count = 0;
        for(var i=0; i<n; i++){
            prefixXor ^= arr[i];
            int countOfCumXor = 0, subArrWithCumXor = 0;
            if(countOfCumulativeXor.ContainsKey(prefixXor)) countOfCumXor = countOfCumulativeXor[prefixXor];
            if(subArrWithCumulativeXor.ContainsKey(prefixXor)) subArrWithCumXor = subArrWithCumulativeXor[prefixXor];

            // update total count
            count += countOfCumXor * i - countOfCumXor - subArrWithCumXor;

            // update count and occurrence for current xor
            countOfCumulativeXor[prefixXor] = countOfCumXor + 1;
            subArrWithCumulativeXor[prefixXor] = subArrWithCumXor + i;
        }

        return count;
    }
}