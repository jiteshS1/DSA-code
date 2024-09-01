public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] charCount = new int[26];
        int start = 0, end = 0, res = 1;
        charCount[s[0]-'A'] += 1; 

        while(start<s.Length && end<s.Length){
            int len = end-start+1;
            int charHighCount = GetHighest(charCount);
            if(len-charHighCount <= k){
                res = Sys-tem.Math.Max(res, len);
                //Valid move right pointer
                end++;
                if(end<s.Length)
                    charCount[s[end]-'A'] += 1; 
            }else{
                //Not valid move left pointer
                charCount[s[start]-'A'] -= 1; 
                start++;
            }
        }
        return res;
    }
    public int GetHighest(int[] charCount){
        int max = 1;
        for(int i=0; i<26; i++){
            max = System.Math.Max(max, charCount[i]);
        }
        return max;
    }
}
/*
    TC: O(n), SC: O(1)
*/