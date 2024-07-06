object Solution {
    def passThePillow(n: Int, time: Int): Int = {
        // remove full cycles
        val roundTrip = (n-1) * 2;
        val newTime = time % roundTrip

        if(newTime < n){
            // left to right
            newTime + 1
        } else {
            // right to left
            n - (newTime - n) - 1
        }
    }
}