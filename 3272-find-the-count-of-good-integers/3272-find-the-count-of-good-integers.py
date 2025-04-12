class Solution:
    def countGoodIntegers(self, n: int, k: int) -> int:
        unique_sorted_palindromes = self.generateUniqueSortedPalindrome(n, k)
        factorial = self.computeFactorial(n)

        count = 0
        for sorted_palindrome in unique_sorted_palindromes:
            count += self.countCombinations(sorted_palindrome, factorial, n)
        return count

    def generateUniqueSortedPalindrome(self, n, k):
        unique_sorted_palindrome = set()    # the digits in palindrome will be sorted
        start = 10 ** ((n - 1) // 2)        # we need to only compute firstHalf of full number
        end = start * 10                    # we don't want number with more digits
        skip = n % 2                        # for even length, reverse will have same digit count, odd will have 1 less

        for num in range(start, end):
            first_half = str(num)
            second_half = first_half[::-1][skip:]
            palindrome_str = first_half + second_half
            palindrome_num = int(palindrome_str)

            # if it is palindrome, we sort its digits, then put in set, to avoid duplicates
            if palindrome_num % k == 0:
                chars = sorted(palindrome_str)
                unique_sorted_palindrome.add(''.join(chars))

        return unique_sorted_palindrome

    def countCombinations(self, palindrome, factorial, n):
        freq = [0] * 10
        for ch in palindrome:
            freq[int(ch)] += 1

        # to count all permutations of these digits, we use multinomial coefficient formula
        # it accounts for all unique permutations by dividing the redundancies caused by repeated digits.
        # numerator = n! (count of all possible arrangements of n digits)
        # denominator = freq(0)! * freq(1)! * freq(2)! .... freq(9)! 

        # permutations of the digits (including leading zeros)
        all_permutations = factorial[n]
        for count in freq:
            if count > 1:
                all_permutations //= factorial[count]

        # permutations that start with zero
        zero_permutations = 0
        if freq[0] > 0:
            freq[0] -= 1
            zero_permutations = factorial[n - 1]    # n-1 because we removed 1 digit
            for count in freq:
                if count > 1:
                    zero_permutations //= factorial[count]

        return all_permutations - zero_permutations

    def computeFactorial(self, n):
        factorial = [1] * (n + 1)
        for i in range(1, n + 1):
            factorial[i] = factorial[i - 1] * i
        return factorial