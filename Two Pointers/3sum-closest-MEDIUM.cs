public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        //Sort array
        Array.Sort(nums);
        int res = nums[0] + nums[1] + nums[2];
        int diff = Int32.MaxValue;

        //Fix first num from nums
        for(int i=0; i<nums.Length-2; i++){
            int l = i+1, r= nums.Length-1;

            while(l<r){
                //Calculate 3 sum
                int sum = nums[i] + nums[l] + nums[r];
                int tDiff = target - sum;

                if(sum > target){
                    r--;
                }else if(sum < target){
                    l++;
                }else{
                    return sum;
                }
                tDiff = Math.Abs(tDiff);
                if(tDiff < diff){
                    diff = tDiff;
                    res = sum; 
                }
            }
        }
        return res;
    }
}
/*
    TC: O(n^2)
    SC: O(logn)
*/