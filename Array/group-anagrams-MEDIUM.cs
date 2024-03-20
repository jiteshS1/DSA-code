public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, IList<string>>();
        foreach(var str in strs){
            char[] ch = str.ToCharArray();
            Array.Sort(ch);

            string word = new String(ch);
            if(dict.ContainsKey(word)){
                dict[word].Add(str);
            }else{
                dict.Add(word, new List<string>(){str});
            }
        }
        var result = new List<IList<string>>();
        foreach(var kvp in dict){
            result.Add(kvp.Value);
        }
        return result;
    }
}
/*
Time complexity: O(n∗m∗logm)
    where n is number of string in strs and m is length of string
    m * log m is TC for Array.Sort()
Space complexity: O(n)

*/