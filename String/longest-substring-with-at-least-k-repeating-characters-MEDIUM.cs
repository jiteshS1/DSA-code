public class Solution {
    public int LongestSubstring(string s, int k) {
        return ProcessSubstring(s, k);
    }

    private int ProcessSubstring(string s, int k){
        if (s.Length == 0) return 0;

        int[] count = new int[26];
        foreach (char c in s) {
            count[c - 'a']++;
        }

        bool fullStringValid = true;
        foreach (char c in s) {
            if (count[c - 'a'] < k) {
                fullStringValid = false;
                break;
            }
        }
        if (fullStringValid) {
            return s.Length;
        }

        int maxLen = 0, start = 0;
        for (int i = 0; i < s.Length; i++) {
            if (count[s[i] - 'a'] < k) {
                maxLen = Math.Max(maxLen, ProcessSubstring(s.Substring(start, i - start), k));
                start = i + 1;
            }
        }
        maxLen = Math.Max(maxLen, ProcessSubstring(s.Substring(start), k));
        return maxLen;
    }
}
/*
    TC: O(n^2)
    SC: O(n)
*/