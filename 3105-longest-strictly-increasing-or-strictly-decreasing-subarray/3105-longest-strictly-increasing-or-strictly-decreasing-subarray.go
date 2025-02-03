func longestMonotonicSubarray(nums []int) int {
    inc, dec, maxLen := 1, 1, 1

    for i := 1; i < len(nums); i++ {
        if nums[i] > nums[i-1] {
            inc++
            dec = 1
        } else if nums[i] < nums[i-1] {
            dec++;
            inc = 1
        } else {
            inc = 1
            dec = 1
        }

        maxLen = max(maxLen, inc, dec)
    }
    
    return maxLen;
}

func max(a, b, c int) int {
    if a > b {
        if a > c {
            return a
        }
        return c
    }
    if b > c {
        return b
    }
    return c
}