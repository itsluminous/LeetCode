func minimumSteps(s string) int64 {
    n := len(s)
    var swaps int64 = 0
    left, right :=  n-1, n-1

    for left >= 0 {
        if s[left] == '1' {
            swaps += int64(right - left)
            right -= 1
        }
        left -= 1
    }

    return swaps
}