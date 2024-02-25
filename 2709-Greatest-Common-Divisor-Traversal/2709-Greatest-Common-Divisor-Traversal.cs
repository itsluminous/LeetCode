// find all possible factors of biggest number in the array
// every other number in this array should union with at least one of these factors for a valid traversal
public class Solution {
    public bool CanTraverseAllPairs(int[] nums) {
        int n = nums.Length, maxNum = nums.Max(), minNum = nums.Min();
        if(n == 1) return true;
        if(minNum == 1) return false;   // because gcd will be 1
        var factorArr = CalculateFactors(maxNum);

        var uf = new UnionFind(maxNum+1);
        foreach(var num in nums){
            var curr = num;
            // link this number to all its factors
            while(curr > 1){
                var factor = factorArr[curr];
                uf.Union(num, factor);
                while(curr % factor == 0)  curr /= factor;
            }
        }

        // find out if any number is not part of the unionFind set
        var parent = uf.Find(nums[0]);
        for(var i=1; i<n; i++){
            if(uf.Find(nums[i]) != parent)
                return false;
        }
        return true;
    }

    // Find smallest divisor for each number
    private int[] CalculateFactors(int num){
        var divisor = new int[num+1];
        for(var i=0; i<num+1; i++) divisor[i] = i;
        for(var i=2; i<=num; i++){
            if(divisor[i] != i) continue;   // means we already know divisor for this one
            for(var j=i*2; j<=num; j+=i)
                if(divisor[j] == j) divisor[j] = i;
        }

        return divisor;
    }

    // not using this function
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

public class UnionFind{
    int[] parent;
    int[] rank;
    
    public UnionFind(int n){
        parent = new int[n];
        rank = new int[n];
        for(int i=0; i<n; i++){
            parent[i] = i;  // all are self parent initially
            rank[i] = 1;
        }
    }
    
    public int Find(int num){
        if(parent[num] != num)
            parent[num] = Find(parent[num]);
        return parent[num];
    }
    
    public void Union(int num1, int num2){
        var num1_p = Find(num1);
        var num2_p = Find(num2);
        if(num1_p == num2_p) return;
        if(rank[num1_p] < rank[num2_p])
            (num1_p, num2_p) = (num2_p, num1_p);    // swap using tuple deconstruction
        parent[num2_p] = num1_p;
        rank[num1_p] += rank[num2_p];
    }
}