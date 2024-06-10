func numberOfChild(n int, k int) int {
    n--    // each round will go till (n-1) only

    rounds := k / n
    k %= n

    // if even rounds, then left to right else right to left
    if rounds & 1 == 1 {
        return n - k
    }
    return k   
}