public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>();
        int count = 0;
        foreach(int num in nums){
            pq.Enqueue(num, num);
            count++;
            if(count > k){
                pq.Dequeue();
                count--;
            }
        }
        return pq.Dequeue();
    }
}
/*
TC: O(n*log k), SC: O(k)
*/