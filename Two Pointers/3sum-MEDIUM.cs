public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        //Sort array
        Array.Sort(nums); //O(n * log n)
        IList<IList<int>> res = new List<IList<int>>();
        for(int i=0; i<nums.Length; i++){
            if(i>0 && nums[i]==nums[i-1])
                continue; //Skipping duplicates
            int l = i+1, 
                r = nums.Length-1;               

            var triplets = new List<int>();
            while(l < r){
                int threeSum = nums[i] + nums[l] + nums[r];
                
                if(threeSum > 0){
                    r--;
                }else if(threeSum < 0){
                    l++;
                }else{
                    triplets.Add(nums[i]);
                    triplets.Add(nums[l]);
                    triplets.Add(nums[r]);
                    res.Add(triplets);
                    triplets = new List<int>();
                    l++;
                    while(nums[l] == nums[l-    1] && l<r)
                        l++;
                } 
            }
        }
        return res;
    }
}
/*
#Brute force solution: TC:O(n^3)
- Try every combination
    - If all condition met true
    - then add all these three nums in list

#Optimized solution:
TC: O(n log n) + O(n^2) = O(n^2)
SC:
*/