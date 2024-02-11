public class KthLargest {
    System.Collections.Generic.PriorityQueue<int, int> q;
    int k;
    public KthLargest(int k, int[] nums) {
        this.k=k;
        q = new(k);
        for(int i=0; i<nums.Length; i++){
            AddValueInHeap(nums[i]);
        }
    }
    
    public int Add(int val) {
        AddValueInHeap(val);
        return q.Peek();
    }
    public void AddValueInHeap(int val){
        if(q.Count<k){
            q.Enqueue(val, val);
        }else if(val > q.Peek()){
                q.Dequeue();
                q.Enqueue(val, val);
            }
    }
}
/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */