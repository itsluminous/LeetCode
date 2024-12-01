func checkIfExist(arr []int) bool {
    nums := make(map[int]struct{})
    for _, num := range arr {
        if _, exists := nums[num * 2]; exists {
            return true
        }
        if num % 2 == 0 {
            if _, exists := nums[num / 2]; exists {
                return true
            }
        }
        nums[num] = struct{}{}
    }
    return false;
}