public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var res = new List<IList<int>>();
        var temp = new List<int>();
        GetSubSets(0, res, temp, nums);
        return res;
    }
    void GetSubSets(int i, IList<IList<int>> res, IList<int> temp, int[] nums){
        if(i >= nums.Length)
        {
            res.Add(new List<int>(temp));
            return;
        }
        
        //Include current value in subset
        temp.Add(nums[i]);
        GetSubSets(i+1, res, temp, nums);

        //Don't include current value in subset
        temp.RemoveAt(temp.Count()-1);
        GetSubSets(i+1, res, temp, nums);
    }

}
/*
TC, SC: O(2^n) 
Image question input like a tree & think solution accordingly, watch neetcode video for reference
https://www.youtube.com/watch?v=REOH22Xwdkk


*/