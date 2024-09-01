/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<double> AverageOfLevels(TreeNode root) {
        //Q: [15, 7]
        //Declaring variables
        var res = new List<double>();
        var qu = new Queue<TreeNode>();
        
        //Enqueue root node in queue
        qu.Enqueue(root);

        //Loop till queue is empty
        while(qu.Count > 0){
            int count = qu.Count, curCount = 0;
            long sum = 0;
            //Loop given count elements from qu
            while(curCount < count){
                var node = qu.Dequeue();
                sum += node.val;
                curCount++;
                //If left & right child present then enqueue
                if(node.left != null){
                    qu.Enqueue(node.left);
                }
                if(node.right != null){
                    qu.Enqueue(node.right);
                }
            }
            //Calculate average
            double avg = (double) sum/count;
            res.Add(avg);
        }

        return res;
    }
}
/*
TC, SC: O(n)
Enqueue root node in queue
- Loop till queue is empty
    - get count of queue
        - dequeue till this count
            - Check node (Dequeued) have  left & right node then insert
            - Add node val in sum
        - Calculate average sum/count
        - Inset in list

-100000
*/