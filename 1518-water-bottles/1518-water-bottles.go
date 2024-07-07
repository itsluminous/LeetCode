func numWaterBottles(numBottles int, numExchange int) int {
    count := numBottles
    for numBottles >= numExchange {
        converted := numBottles / numExchange
        remaining := numBottles % numExchange
        count += converted

        numBottles = converted + remaining
    }

    return count
}