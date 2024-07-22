func minNumberOperations(target []int) int {
    ops, incr := 0, 0
    for _, num := range target {
        if num > incr {
            ops += (num - incr)
        }
        incr = num
    }
    return ops
}