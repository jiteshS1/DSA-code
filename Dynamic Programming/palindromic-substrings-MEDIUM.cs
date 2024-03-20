public class Solution {
    int count=0;
    public int CountSubstrings(string s) {
        for(int i=0; i<s.Length; i++){
            CheckPalindrome(s, i, i);
            CheckPalindrome(s, i, i+1);
        }
        return count;
    }
    public void CheckPalindrome(string s, int l, int r){
        while(l>=0 && r<s.Length && s[l]==s[r]){
            count++;
            l--;
            r++;
        }
    }
}
/*
Loop each char in string
    #For odd palindrome sub string
    For each char expand l & r outwards check if string is palindrom
        If(true)
            Increment counter

    #For even palindrome sub string
    For each char expand l & r+1 outwards check if string is palindrom
        If(true)
            Increment counter

*/