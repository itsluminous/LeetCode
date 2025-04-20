// idea in both approach is that if there are n rabbits who answer same number
// then, we can make (n / num+1) groups + (n % num+1) groups with remaining rabbits
// and in each group we will have num+1 rabbits, so count would be group * num+1

// O(n)
class Solution {
    public int numRabbits(int[] answers) {
        var freq = new HashMap<Integer, Integer>();
        for(var ans : answers)
            freq.put(ans, freq.getOrDefault(ans, 0) + 1);

        var rabbits = 0;
        for(var curr : freq.keySet()){
            var currCount = freq.get(curr);
            var groups = (currCount + curr) / (curr + 1);   // equivalent of Math.ceil
            rabbits += groups * (curr + 1);
        }

        return rabbits;
    }
}

// Accepted : O(n log(n))
class SolutionSort {
    public int numRabbits(int[] answers) {
        Arrays.sort(answers);
        var rabbits = 0;

        for(var i=0; i<answers.length;){
            int curr = answers[i++], currCount = 1;
            while(i < answers.length && answers[i] == curr) {
                i++;
                currCount++;
            }

            var groups = (currCount + curr) / (curr + 1);   // equivalent of Math.ceil
            rabbits += groups * (curr + 1);
        }

        return rabbits;
    }
}