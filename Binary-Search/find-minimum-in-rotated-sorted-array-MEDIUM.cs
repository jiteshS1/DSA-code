public class Solution {
    public int FindMin(int[] nums) {
        int l=0, r=nums.Length-1, m=0, min=0;
        while(l<=r){
            m = l + (r-l)/2;
            if(nums[m] < nums[l] && nums[m] < nums[r]){
                r = m;
            }else if(nums[l] < nums[m] && nums[l] < nums[r]){
                r = m-1;
            }else if(nums[r] < nums[m] && nums[r] < nums[l]){
                l = m+1;
            }else return nums[m];
        }
        return nums[l];
    }
}
/*
Use BS
 if m value is less from l,m,r
    then r = m find new m
    else if l value is less
        r=m-1 find m
    else if r is small
        l=m+1 find m
    

Solution with less if conditions:
Classic binary search problem.

Looking at subarray with index [start,end]. We can find out that if the first member is less than the last member, there's no rotation in the array. So we could directly return the first element in this subarray.

If the first element is larger than the last one, then we compute the element in the middle, and compare it with the first element. If value of the element in the middle is larger than the first element, we know the rotation is at the second half of this array. Else, it is in the first half in the array.

 int findMin(vector<int> &num) {
        int start=0,end=num.size()-1;
        
        while (start<end) {
            if (num[start]<num[end])
                return num[start];
            
            int mid = (start+end)/2;
            
            if (num[mid]>=num[start]) {
                start = mid+1;
            } else {
                end = mid;
            }
        }
        
        return num[start];
    }
*/