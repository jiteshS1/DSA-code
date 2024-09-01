public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        var res = new List<string>();
        if(s.Length<10){
            return res;
        }
        
        var dict = new Dictionary<string, int>();

        int l=0, r=9;
        
        while(r<s.Length){
            string subString = s.Substring(l, 10);
            if(dict.ContainsKey(subString)){
                //Sequence already present
                //Check if it is 1st duplicate
                var len = dict[subString];
                if(len==1){
                    //Add in result
                    res.Add(subString);
                    dict[subString] += 1;
                }
            }else{
                //Add in dictionary
                dict.Add(subString, 1);
            }
            l++;
            r++;
        }
        return res;
    }
}

/*
TC, SC: O(n)
- If length of string is less then 10
    - return empty list

- Sliding window length will be 10
*/