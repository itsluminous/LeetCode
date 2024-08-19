func minSteps(n int) int {
    count := 0
    for n != 1 {
        for div := 2; div <= n; div++ {
            if n % div != 0 {
                continue
            }
            n /= div
            count += div
            break
        }
    }
    return count
}