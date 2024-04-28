public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int head = 0, tail = numbers.Length-1;
        int[] res = new int[2];
        while(head<tail){
            int curSum = numbers[head] + numbers[tail];
            if(target == curSum)
            {
                res[0]= head+1;
                res[1]= tail+1;
                break;
            }else if(target > curSum){
                head++;
            }else if(target < curSum){
                tail--;
            }
        }
        return res;
    }
}

/*
TC: O(n) SC: O(1)
Two pointer
- head = 0, tail = length-1
- Loop till head<tail
    - if current sum is equal to target
        - add both index in result & return
    - if target is more then current sum value
        - increase head by 1
    - if target is less then  current sum value
        - decrease tail by 1

UT: -4,-2,-1,0,1,2
*/