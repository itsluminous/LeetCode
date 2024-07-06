# @param {Integer} n
# @param {Integer} time
# @return {Integer}
def pass_the_pillow(n, time)
    # remove full cycles
    roundTrip = (n-1) * 2
    time %= roundTrip

    if time < n
        # left to right
        time + 1
    else
        # right to left
        time -= n
        n - time - 1
    end
end