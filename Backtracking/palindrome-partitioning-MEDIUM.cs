public class Solution {
    public IList<IList<string>> Partition(string s) {
        var res = new List<IList<string>>();
        DFS(0, s, res, new List<string>());
        return res;
    }
    public void DFS(int i, string s, 
        List<IList<string>> res, List<string> temp)
    {
        if(i >= s.Length)
        {
            res.Add(new List<string>(temp));
            return;
        }
        for(int ind = i; ind < s.Length; ind++){
            if(isPalindrome(s, i, ind)){
                string tRes = s.Substring(i, ind-i+1);
                temp.Add(tRes);
                DFS(ind+1, s, res, temp);
                temp.RemoveAt(temp.Count()-1);
            }
        }
    }
    public bool isPalindrome(string s, int i, int j){
        while(i<j){
            if(s[i] != s[j])
                return false;
            i++;
            j--;
        }
        return true;
    }
}