func minimumOperations(nums []int, target []int) int64 {
    n := len(nums)
    var incr, decr, ops int64

    for i:=0; i<n; i++ {
        diff := int64(target[i] - nums[i])

        if diff > 0 {
            if incr < diff {
                ops += diff - incr
            }
            incr = diff
            decr = 0
        } else if diff < 0 {
            if diff < decr {
                ops += decr - diff
            }
            decr = diff
            incr = 0
        } else {
            incr = 0
            decr = 0
        }
    }

    return ops
}