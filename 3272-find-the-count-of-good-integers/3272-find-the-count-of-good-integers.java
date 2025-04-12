class Solution {
    public long countGoodIntegers(int n, int k) {
        var uniqueSortedPalindromes = generateUniqueSortedPalindrome(n, k);
        var factorial = computeFactorial(n);

        long count = 0;
        for(var sortedPalindrome : uniqueSortedPalindromes)
            count += countCombinations(sortedPalindrome, factorial, n);
        return count;
    }

    private Set<String> generateUniqueSortedPalindrome(int n, int k) {
        var uniqueSortedPalindrome = new HashSet<String>(); // the digits in palindrome will be sorted
        var start = (int) Math.pow(10, (n - 1) / 2); // we need to only compute firstHalf of full number
        var end = start * 10;   // we don't want number with more digits
        var skip = n % 2;       // for even length, reverse will have same digit count, odd will have 1 less

        for (var num = start; num < end; num++) {
            var firstHalf = Integer.toString(num);
            var secondHalf = new StringBuilder(firstHalf).reverse().substring(skip);
            var palindromeStr = firstHalf + secondHalf;
            var palindromeNum = Long.parseLong(palindromeStr);

            // if it is palindrome, we sort its digits, then put in set, to avoid duplicates
            if(palindromeNum % k == 0) {
                var chars = palindromeStr.toCharArray();
                Arrays.sort(chars);
                uniqueSortedPalindrome.add(new String(chars));
            }
        }
        return uniqueSortedPalindrome;
    }

    private long countCombinations(String palindrome, long[] factorial, int n) {
        var freq = new int[10];
        for(var ch : palindrome.toCharArray())
            freq[ch - '0']++;
        
        // to count all permutations of these digits, we use multinomial coefficient formula
        // it accounts for all unique permutations by dividing the redundancies caused by repeated digits.
        // numerator = n! (count of all possible arrangements of n digits)
        // denominator = freq(0)! * freq(1)! * freq(2)! .... freq(9)! 

        // permutations of the digits (including leading zeros)
        var allPermutations = factorial[n];
        for(var count : freq) {
            if (count > 1) {
                allPermutations /= factorial[count];
            }
        }

        // permutations that start with zero
        long zeroPermutations = 0;
        if(freq[0] > 0) {
            freq[0]--;
            zeroPermutations = factorial[n - 1];    // n-1 because we removed 1 digit
            for(var count : freq) {
                if (count > 1) {
                    zeroPermutations /= factorial[count];
                }
            }
        }

        return allPermutations - zeroPermutations;
    }

    private long[] computeFactorial(int n) {
        var factorial = new long[n + 1];
        factorial[0] = 1;
        for(var i = 1; i <= n; i++)
            factorial[i] = factorial[i - 1] * i;
        return factorial;
    }
}