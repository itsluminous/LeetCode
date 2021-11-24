public class Solution {
    Dictionary<int, int> dict = new Dictionary<int, int>(); // key is the factor, value is index of first num with that factor
    UnionFind uf;                                           // unionfind will maintain multiple sets for each factor
    public int LargestComponentSize(int[] nums) {
        var n = nums.Length;
        uf = new UnionFind(n);
        
        for (int i = 0; i < n; i++){                    // for each number in input array
            var num = nums[i];                          // the current number we are processing
            StartNewSetOrJoin(num, i, num);             // the number is a factor of itself
            for (int j = 2; j*j <= num; j++){           // j*j <= num because we want to only check factors till square root of num
                if (num % j == 0){                      // if j is a factor of num
                    StartNewSetOrJoin(num, i, j);       // add current num to set of factor j
                    StartNewSetOrJoin(num, i, num/j);   // obviously num/j is also a factor of num 
                }
            }
        }
        
        return uf.max;
    }
    
    private void StartNewSetOrJoin(int num, int numIdx, int factor){
        if (!dict.ContainsKey(factor)){         // no number has had this factor yet
            dict[factor] = numIdx;              // so a new set starts with current number
        }else{                                  // if there is already a set with current factor as parent
            uf.Union(numIdx, dict[factor]);     // join current number with that set
        }
    }
}


public class UnionFind{
    int[] parent;                           // it stores index of first node in a set
    int[] size;                             // keeps track of size of a set
    public int max;                         // this we maintain so that we don't have to do a loop later to get biggest set
    
    public UnionFind(int n){
        parent = new int[n];
        size = new int[n];
        max = 1;                            // all disjoint sets have one node
        for(int i=0; i<n; i++){
            parent[i] = i;                  // all are self parent initially
            size[i] = 1;                    // size of all disjoint sets is 1 initially
        }
    }
    
    public int Find(int n){
        if(parent[n] != n)                  // if there are multiple nodes in current set
            parent[n] = Find(parent[n]);    // find parent node of the set
        return parent[n];                   // and then return the parent
    }
    
    public void Union(int n1, int n2){
        var n1_p = Find(n1);                // find parent of number 1
        var n2_p = Find(n2);                // find parent of number 2
        if(n1_p != n2_p){                   // if parent of number 1 and number 2 are not same, then we need to join two sets
            parent[n1_p] = n2_p;            // make n2's parent as common parent for both sets. ideally smaller set should update its parent
            size[n2_p] += size[n1_p];       // update size of the merged set
            max = Math.Max(max, size[n2_p]);// update the max size of any set
        }
        
    }
}