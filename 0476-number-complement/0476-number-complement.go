func findComplement(num int) int {
    // step 1 : get a mask which has all bits set to 1 (starting from first 1 bit)
    // so mask for num 0000101001 will be 0000111111
    mask := getMask(num)

    // step 2 : xor the mask with num, so that only bits originally 0 will be set
    return num ^ mask
}

func getMask(num int) int {
    mask := num
    // Copy the highest 1-bit onto all the lower bits
    for num != 0 {
        num >>= 1
        mask |= num
    }
    return mask
}