// the trick is that no. of swaps needed will always be no. of mismatches / 2
// https:#assets.leetcode.com/users/images/0731629f-ae07-4507-bfc4-a7b1bea289b6_1628395785.653253.png
func minSwaps(s string) int {
    mismatch := 0
        for _, ch := range s {
            if ch == '[' {
                mismatch++
            } else if mismatch > 0 {
                mismatch -= 1
            }
        }
        return (mismatch + 1) / 2
}