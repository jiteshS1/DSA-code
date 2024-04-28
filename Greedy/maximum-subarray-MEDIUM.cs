public class Solution {
    public int MaxSubArray(int[] nums) {
        int res = Int32.MinValue, cur=0;
        foreach(int num in nums){
            cur += num;
            if(cur > res)
                res = cur;
            
            if(cur<0)
                cur = 0;
        }
        return res;
    }
}
/*
TC: O(n), SC: O(1)
Don't consider -ve prefix value while adding nums
*/