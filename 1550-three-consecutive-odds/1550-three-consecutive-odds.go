func threeConsecutiveOdds(arr []int) bool {
    odd := 0
    for _, num := range arr {
        if num & 1 == 1 {
            odd++
        } else {
            odd = 0
        }

        if odd == 3 {
            return true
        }
    }

    return false
}