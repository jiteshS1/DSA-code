public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        int l = 0, m=0, r = 0;
        int oddNumCount = 0, res = 0;

        while(r<nums.Length){
            if(nums[r]%2==1)
                oddNumCount++;
            
            while(l<nums.Length && oddNumCount>k){
                if(nums[l]%2==1){
                    //If num is odd then reduce count
                    oddNumCount--;
                }
                l++;
                m=l;
            }
            if(oddNumCount==k){
                //Make middle pointer to 1st odd num position
                while(m<nums.Length){
                    if(nums[m]%2 == 0){
                        m++;
                    }else{
                        break;
                    }
                }
                //Calculate possible sub array for this valid odd num count
                res = res + m - l + 1;
            }
            r++;
        }

        return res;
    }
}
/*
    TC: O(n), SC: O(1)
*/