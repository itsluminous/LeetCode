func decrypt(code []int, k int) []int {
    n := len(code)
    ans := make([]int, n)
    if k == 0 {
        return ans
    }

    sum, l, r := 0, 1, k
    if k < 0 {
        k = -k
        l = n - k  // l is now actually end of array
        r = n - 1  // r is start of array
    }
    
    for i:=l; i<=r; i++ {
        sum += code[i]
    }

    for i := 0; i < n; i++ {
        ans[i] = sum
        sum -= code[l]
        l = (l + 1) % n
        r = (r + 1) % n
        sum += code[r]
    }

    return ans
}