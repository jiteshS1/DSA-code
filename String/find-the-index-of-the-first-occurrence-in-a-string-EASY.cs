public class Solution {
    public int StrStr(string haystack, string needle) {
        int curInd = 0, startIndex = -1;
        char[] hsCh = haystack.ToCharArray(),
            neCh = needle.ToCharArray();
        if(hsCh.Length < neCh.Length) return startIndex;
        for(int i=0; i<hsCh.Length && curInd != neCh.Length; i++){
            if(hsCh[i] == neCh[curInd])
            {
                if(startIndex == -1)
                    startIndex = i; 
                curInd++;
            }else{
                //Reset
                if(startIndex >= 0)
                    i = startIndex;
                startIndex = -1;
                curInd = 0;
            }
        }
        return (curInd == neCh.Length)? startIndex:-1;
    }
}
/*
    currInd=0
    Loop chars in needle
        if char == hsCh
            startIndex=i; currInd++;
        if(startIndex>=0 && char == hsCh)
            currInd++;continue;
        else 
            startIndex=-1

        if curreIn >=Length of hsCh

*/