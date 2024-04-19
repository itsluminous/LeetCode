// Logic :
// 1. If length is not same, they can never be close
// 2. If count of distinct letters in word1 & word2 is not same, they can never be close
// 3. If distinct letters in word1 & word2 are not same, they can never be close because swapping will not fix it
// 4. If frequency of different letters in word1 & word2 are not same, they can never be close

public class Solution {
    public bool CloseStrings(string word1, string word2) {
        if(word1.Length != word2.Length) return false;      // case-1

        int[] arr1 = new int[26],  arr2 = new int[26];
        for(var i=0; i<word1.Length; i++){
            arr1[word1[i] - 'a']++;
            arr2[word2[i] - 'a']++;
        }

        for(var i=0; i<26; i++)
            if(arr1[i] !=0 && arr2[i] == 0) 
                return false;   // case-2 & case-3

         Array.Sort(arr1);
         Array.Sort(arr2);

         return arr1.SequenceEqual(arr2);   // case-4
    }
}

// This also passes, using dictionary
public class SolutionDict {
    public bool CloseStrings(string word1, string word2) {
        if(word1.Length != word2.Length) return false;      // case-1

        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        for(var i=0; i<word1.Length; i++){
            if(dict1.ContainsKey(word1[i])) dict1[word1[i]]++;
            else dict1[word1[i]] = 1;

            if(dict2.ContainsKey(word2[i])) dict2[word2[i]]++;
            else dict2[word2[i]] = 1;
        }

        if(dict1.Keys.Count != dict2.Keys.Count) return false;  // case-2
        var keysEqual = dict1.Keys.OrderBy(k => k).SequenceEqual(dict2.Keys.OrderBy(k => k));
        var valuesEqual = dict1.Values.OrderBy(k => k).SequenceEqual(dict2.Values.OrderBy(k => k));

        return keysEqual && valuesEqual;    // case-3 & case-4
    }
}

// word1 : "aaabbbbccddeeeeefffff"
// word2 : "aaaaabbcccdddeeeeffff"
// output : false