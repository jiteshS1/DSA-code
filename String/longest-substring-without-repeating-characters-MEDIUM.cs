public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var list = new HashSet<char>();
        int len=0,maxLen=0, startIndex=-1;
        for(int i=0; i<s.Length; i++){
            if(!list.Contains(s[i]))//Not present
            {
                if(startIndex==-1)
                    startIndex=i;
                list.Add(s[i]);
                len++;
            }else{//Present
                if(maxLen<len)
                    maxLen=len;
                len=0;
                list.Clear();
                i=startIndex;
                startIndex = -1;
            }
        }
        return maxLen<len? len:maxLen;
    }
}
/*
Loop each char of s
    Check if char c value in array is = 0
        +1
        length++
    if char c value in arra >1
        repeated
        if maxLen<len then maxLen =len
        //Reset that array with values 0

return maxLen

-------------Better Approach--------------------
The idea is use a hash set to track the longest substring without repeating characters so far, use a fast pointer j to see if character j is in the hash set or not, if not, great, add it to the hash set, move j forward and update the max length, otherwise, delete from the head by using a slow pointer i until we can put character j to the hash set.
public int lengthOfLongestSubstring(String s) {
    int i = 0, j = 0, max = 0;
    Set<Character> set = new HashSet<>();
    
    while (j < s.length()) {
        if (!set.contains(s.charAt(j))) {
            set.add(s.charAt(j++));
            max = Math.max(max, set.size());
        } else {
            set.remove(s.charAt(i++));
        }
    }
    
    return max;
}
*/