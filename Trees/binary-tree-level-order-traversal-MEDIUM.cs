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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root == null) return res;
        System.Collections.Generic.Queue<TreeNode> q = new();
        q.Enqueue(root);
        while(q.Count!=0){
            int level = q.Count;
            List<int> tmp = new();
            for(int i=1; i<=level && q.Count>0; i++){
                if(q.Peek().left != null)
                    q.Enqueue(q.Peek().left);
                if(q.Peek().right != null)
                    q.Enqueue(q.Peek().right);
                
                tmp.Add(q.Dequeue().val);
            }
            if(tmp.Count>0)
                res.Add(tmp);
        }
        return res;
    }
}