function numWaterBottles(numBottles: number, numExchange: number): number {
    let count = numBottles;
    while(numBottles >= numExchange){
        const converted = Math.floor(numBottles / numExchange);
        const remaining = numBottles % numExchange;
        count += converted;

        numBottles = converted + remaining;
    }

    return count;
};