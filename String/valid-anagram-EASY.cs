public class Solution {
    public bool IsAnagram(string s, string t) {
        char[] sChars = s.ToCharArray(),
            tChars = t.ToCharArray();
        int[] array = new int[26];

        for(int i=0; (i<sChars.Length || i<tChars.Length); i++){
            if(i<sChars.Length)
            {
                array[sChars[i]-97] += 1;
            }
            if(i<tChars.Length)
            {
                array[tChars[i]-97] -= 1;
            }
        }
        int j=0;
        while(j<26)
        {
            if(array[j++]!=0)
                return false;
        }
        return true;
    }
}
/*
ASCI of small alphabets starts from 97
Loop chars in s
    make char index +1

Loop chars in t
    make char index -1

Loop array each element should be 0
*/