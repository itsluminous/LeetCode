// idea in both approach is that if there are n rabbits who answer same number
// then, we can make (n / num+1) groups + (n % num+1) groups with remaining rabbits
// and in each group we will have num+1 rabbits, so count would be group * num+1

// O(n)
public class Solution {
    public int NumRabbits(int[] answers) {
        var freq = new Dictionary<int, int>();
        foreach(var ans in answers)
            if(freq.ContainsKey(ans)) freq[ans]++;
            else freq[ans] = 1;

        var rabbits = 0;
        foreach(var curr in freq.Keys){
            var currCount = freq[curr];
            var groups = (currCount + curr) / (curr + 1);   // equivalent of Math.ceil
            rabbits += groups * (curr + 1);
        }

        return rabbits;
    }
}

// Accepted : O(n log(n))
public class SolutionSort {
    public int NumRabbits(int[] answers) {
        Array.Sort(answers);
        var rabbits = 0;

        for(var i=0; i<answers.Length;){
            int curr = answers[i++], currCount = 1;
            while(i < answers.Length && answers[i] == curr) {
                i++;
                currCount++;
            }

            var groups = (currCount + curr) / (curr + 1);   // equivalent of Math.ceil
            rabbits += groups * (curr + 1);
        }

        return rabbits;
    }
}