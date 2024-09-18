class Solution {
    public String largestNumber(int[] nums) {
        // handle edge case - when all numbers are 0, then return single 0
        if (Arrays.stream(nums).allMatch(num -> num == 0)) return "0";

        // convert array to string
        String[] strNums = Arrays.stream(nums)
                                 .mapToObj(String::valueOf)
                                 .toArray(String[]::new);

        // sort the strings with custom logic
        Arrays.sort(strNums, new Comparator<String>() {
            @Override
            public int compare(String s1, String s2) {
                return (s2 + s1).compareTo(s1 + s2);
            }
        });

        // join all the strings
        return String.join("", strNums);
    }
}