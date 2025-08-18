public class Solution {
    double delta = 0.001;   // to keep decimal till 3 places only

    public bool JudgePoint24(int[] cards) {
        var arr = new List<double>();
        foreach(var card in cards) arr.Add((double)card);
        return Evaluate(arr);
    }

    private bool Evaluate(List<double> arr){
        if(arr.Count == 1){
            if(Math.Abs(arr[0] - 24.0) < delta)
                return true;
            return false;
        }

        // try all permutations of two numbers
        for(var i=0; i<arr.Count; i++){
            for(var j=0; j<i; j++){
                var next = new List<double>();
                double n1 = arr[i], n2 = arr[j];

                // add all possible operations between n1 & n2
                next.AddRange(new List<double> { n1 + n2, n1 - n2, n2 - n1, n1 * n2 });
                if(Math.Abs(n1) > delta) next.Add(n2/n1);
                if(Math.Abs(n2) > delta) next.Add(n1/n2);

                // backtracking
                arr.RemoveAt(i);
                arr.RemoveAt(j);
                foreach(var nxt in next){
                    arr.Add(nxt);
                    if(Evaluate(arr)) return true;
                    arr.RemoveAt(arr.Count - 1);
                }
                arr.Insert(j, n2);
                arr.Insert(i, n1);
            }
        }
        return false;
    }
}