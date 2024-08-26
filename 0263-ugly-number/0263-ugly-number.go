func isUgly(n int) bool {
    if n == 0 {
        return false
    }

    for div:=5; div>1; div-- {
        for n % div == 0 {
            n /= div
        }
    }
    return n == 1
}