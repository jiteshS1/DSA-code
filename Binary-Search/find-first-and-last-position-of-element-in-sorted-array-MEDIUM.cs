public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        //Edge case
        if(nums.Length == 0)
            return new int[2]{-1, -1};
        
        //Declaring variables
        int low = 0, high = nums.Length-1, mid = (low+high)/2;
        int start = -1, last = -1;
        
        //Check if target is present in nums
        while(low <= high){
            if(nums[mid] == target)
            {
                start = mid;
                last = mid;
                break;
            }else if(target > nums[mid]){
                low = mid+1;
            }else{
                high = mid-1;
            }

            //Update mid
            mid = (low+high)/2;
        }

        //Target not found
        if(start == -1){
            return new int[2]{-1, -1}; 
        }else{
            //Target found
            //Check if start & end position is correct
            if(nums[low] == target && nums[high] == target){
                return new int[2]{low, high};
            }else{
                bool checkNeighbours = true;
                while(checkNeighbours){
                    if(start-1 >= 0 && nums[start-1] == nums[start]){
                        checkNeighbours = true;
                        start--;
                    }else
                        checkNeighbours = false;
                    
                    if(last+1 < nums.Length && nums[last+1] == nums[last]){
                        checkNeighbours = true;
                        last++;
                    }
                }
                return new int[2]{start, last};
            }
        }

    }
}
/*
Brute solution will take O(n) time

Binary search will take log n time
eg: 5,7,7,8,8,10

    1,1,1,1,1,1,1, T=1

My solution was taking O(n) time in worst case

if I use binary search twice then I can get left & right pointer
Solution: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/solutions/5378191/video-binary-search-solution/
*/