# @param {Integer} n
# @return {Boolean}
def can_win_nim(n)
    # return n % 4 != 0
    return (n & 3) != 0
end