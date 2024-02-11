public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> list = new List<int>();
        bool[] map = new bool[nums.Length];
        RecPerm(res, list, map, nums);
        return res;
    }
    public void RecPerm(IList<IList<int>> res, IList<int> list, bool[] map, int[] nums){
    if(list.Count == nums.Length){
        res.Add(new List<int>(list));
        return;
    }
    for(int i=0; i<nums.Length; i++){
        if(map[i]==false)
        {
            list.Add(nums[i]);
            map[i]= true;
            RecPerm(res, list, map, nums);
            list.RemoveAt(list.Count-1);
            map[i]= false;
        }
        
    }
}
}
/*
Above solution is taking extra memory for storing map values, 
TC: n! x n = O(n!), SC: O(n) + O(n) = O(n)

--------Without using map array-------------------------
TC: n! x n = O(n!), SC: O(n) No space required for map array = O(n)

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> list = new List<int>();
        RecPerm(res, list, nums);
        return res;
    }
    public void RecPerm(IList<IList<int>> res, IList<int> list, int[] nums){
        if(list.Count == nums.Length){
            res.Add(new List<int>(list));
            return;
        }
        for(int i=0; i<nums.Length; i++){
            if(!list.Contains(nums[i]))
            {
                list.Add(nums[i]);
                RecPerm(res, list, nums);
                list.RemoveAt(list.Count-1);
            }
        }
    }
}
*/