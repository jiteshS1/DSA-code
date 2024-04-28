public class Solution {
    public IList<int> PartitionLabels(string s) {
        //Caculate last index of each char in Dictionary
        var dict = new Dictionary<char, int>();
        for(int i=0; i<s.Length; i++){
            if(dict.ContainsKey(s[i])){
                dict[s[i]] = i; //Update last index with new value
            }else{
                dict.Add(s[i], i);
            }
        }

        var res = new List<int>();
        int index = -1, start = 0;

        for(int i=0; i<s.Length; i++){
            index = System.Math.Max(dict[s[i]], index);
            if(i == index){
                res.Add(index - start + 1);
                start = i+1;
            }
        }
        return res;
    }
}
/*
TC: O(n), SC: O(1)
*/