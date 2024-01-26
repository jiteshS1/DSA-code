public class Solution {
    public int Search(int[] nums, int target) {
        int l=0, r=nums.Length - 1, m=r/2;
        while(l<=r){
            m = l+((r-l)/2);
            if(nums[m]>target)
                r = m-1;
            else if(nums[m]<target)
                l = m+1;
            else
                return m;
        }
        return -1;
    }
}