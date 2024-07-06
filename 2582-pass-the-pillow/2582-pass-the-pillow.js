/**
 * @param {number} n
 * @param {number} time
 * @return {number}
 */
var passThePillow = function(n, time) {
    // remove full cycles
    var roundTrip = (n-1) * 2;
    time %= roundTrip;

    // left to right
    if(time < n) return time + 1;
    
    // right to left
    time -= n;
    return n - time - 1;
};