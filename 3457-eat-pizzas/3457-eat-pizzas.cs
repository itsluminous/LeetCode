public class Solution {
    public long MaxWeight(int[] pizzas) {
        Array.Sort(pizzas);

        var days = pizzas.Length / 4;
        var even = days / 2;
        var odd = days - even;
        long weight = 0;

        // pick heaviest pizzas on odd days
        var idx = pizzas.Length - 1;
        for(var i=0; i<odd; i++){
            weight += pizzas[idx];
            idx--;
        }

        // pick second heaviest pizzas on even days
        idx--;
        for(var i=0; i<even; i++){
            weight += pizzas[idx];
            idx -= 2;
        }

        return weight;
    }
}