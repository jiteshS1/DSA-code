public class Solution {
    public string LongestPalindrome(string s) {
        string res="";
        for(int i=0; i<s.Length; i++){
            CheckPalindrome(s, i, i, ref res);
            CheckPalindrome(s, i, i+1, ref res);
        }
        return res;
    }
    public void CheckPalindrome(string s, int l, int r, ref string res){
        while(l>=0 && r<s.Length && s[l]==s[r]){
            if(res.Length < s.Substring(l, r-l+1).Length){
                res = s.Substring(l, r-l+1);
            }
            l--;
            r++;
        }
    }
}
/*
#Brute force solution:
- Loop each char in string
    - For each sub string for that char check if it is palindrome
- Basically we are checking each substring whether that is palindrome or not.
TC: O(n^3)

#Optimized solution:
Loop through each letter in s
    Treat that letter as center and expand outwards to see of string is palindrome.

Special case:
Even length palindromic substring 

- Without manipulating string variable again

public class Solution {
    int low=0, maxLen=0;
    public string LongestPalindrome(string s) {
        for(int i=0; i<s.Length; i++){
            CheckPalindrome(s, i, i);
            CheckPalindrome(s, i, i+1);
        }
        return s.Substring(low, maxLen);
    }
    public void CheckPalindrome(string s, int l, int r){
        while(l>=0 && r<s.Length && s[l]==s[r]){
            if(maxLen < s.Substring(l, r-l+1).Length){
                maxLen = s.Substring(l, r-l+1).Length;
                low = l;
            }
            l--;
            r++;
        }
    }
}
*/