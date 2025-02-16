class Solution {
    public long maxWeight(int[] pizzas) {
        Arrays.sort(pizzas);

        var days = pizzas.length / 4;
        var even = days / 2;
        var odd = days - even;
        long weight = 0;

        // pick heaviest pizzas on odd days
        var idx = pizzas.length - 1;
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