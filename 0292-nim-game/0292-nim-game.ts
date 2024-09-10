function canWinNim(n: number): boolean {
    // return n % 4 != 0;
    return (n & 3) != 0;
};