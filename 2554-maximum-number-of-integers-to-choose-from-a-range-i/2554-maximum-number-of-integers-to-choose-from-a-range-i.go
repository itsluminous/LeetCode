func maxCount(banned []int, n int, maxSum int) int {
    bnd := make(map[int]struct{})
    for _, num := range(banned){
        bnd[num] = struct{}{}
    }
    count := 0;
    for num:=1; num<=n; num++ {
        if _, exists := bnd[num]; exists {
            continue;
        }
        if maxSum - num < 0 {
            break;
        }
        maxSum -= num;
        count++;
    }
    
    return count;
}