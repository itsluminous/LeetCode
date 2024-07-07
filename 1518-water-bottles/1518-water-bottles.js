/**
 * @param {number} numBottles
 * @param {number} numExchange
 * @return {number}
 */
var numWaterBottles = function(numBottles, numExchange) {
    let count = numBottles;
    while(numBottles >= numExchange){
        let converted = Math.floor(numBottles / numExchange);
        let remaining = numBottles % numExchange;
        count += converted;

        numBottles = converted + remaining;
    }

    return count;
};