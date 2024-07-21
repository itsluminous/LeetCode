func minChanges(n int, k int) int {
    if n == k {
        return 0
    }
    if n < k {
        return -1
    }

    xor := n ^ k
    if (k & ^n) != 0 {
        return -1
    }

    return bits.OnesCount(uint(xor))
}