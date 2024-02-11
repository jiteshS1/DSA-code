public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        IList<IList<int>> res = new List<IList<int>>();
        CombineRec(1, res, new List<int>(), n, k);
        return res;
    }
    public void CombineRec(int start, IList<IList<int>> res, IList<int> tmp, int n, int k){
        if(tmp.Count == k){
            res.Add(new List<int>(tmp));
            return;
        }
        for(int i=start; i<=n; i++){
            tmp.Add(i);
            CombineRec(i+1, res, tmp, n, k);
            tmp.RemoveAt(tmp.Count-1);
        }
    }
}