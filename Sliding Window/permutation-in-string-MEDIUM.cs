public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int[] charCount = new int[26];
        
        //Count chars in s1
        for(int i=0; i<s1.Length; i++){
            charCount[s1[i] - 'a'] += 1; 
        }

        int l=0, r=0;

        int[] curChars = new int[26];
        curChars[s2[r] - 'a'] += 1;
        while(l<s2.Length && r<s2.Length){
            //Verify if chars are in valid range
            bool isValidCharCount = ValidCharRange(curChars, charCount);
            if(isValidCharCount==false){
                //Remove char count of l index from array
                curChars[s2[l] - 'a'] -= 1;
                if(l == r)
                {
                    l++;
                    r++;
                    if(r<s2.Length){
                        curChars[s2[r] - 'a'] += 1;
                    }
                }else{
                    l++;
                }
            }else{
                //Check if current slding window length is same as s1
                int len = r-l+1;
                if(len==s1.Length)
                    return true;
                else{
                    r++;
                    if(r<s2.Length){
                        curChars[s2[r] - 'a'] += 1;
                    }
                }

            }
        }
        return false;
    }
    public bool ValidCharRange(int[] curChars, int[] charCount){
        for(int i=0; i<26; i++){
            if(curChars[i] > charCount[i])
                return false;
        }
        return true;
    }
}
/*
    TC: O(n1 + n2), SC: O(1)
*/