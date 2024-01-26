public class Solution {
    public bool IsSubsequence(string s, string t) {
        int sInd=0;
        char[] sChars = s.ToCharArray(),
            tChars = t.ToCharArray();
        
        for(int i=0; i<tChars.Length && sInd<sChars.Length; i++){
            if(sChars[sInd]==tChars[i])
                sInd++;
            
            if(sInd==sChars.Length)
                return true;
        }
        return sInd==sChars.Length? true:false;
    }
}
/*
var sInd=0
Loop t chars untl length
    check if at sInd of sChars is same char as tChar
    if Yes 
        then  sInd++;

    if sInd is same as Length of sChars
        then true

if sInd is same as Length of sChars
        then true
return false
*/