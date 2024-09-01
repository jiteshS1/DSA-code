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
    public int GoodNodes(TreeNode root) {
        int left = 0, right = 0;
        int res = 1;
        left = DFS(root.left, root.val);
        right = DFS(root.right, root.val);
        res = res + left + right;
        return res;
    }
    public int DFS(TreeNode node, int max){
        if(node==null)  
            return 0;
            
        int res = 0;
        if(node.val >= max){
            res += 1;
        }
        //Check max
        max = System.Math.Max(max, node.val);
        int left = 0, right = 0;
        if(node.left!=null){
            left = DFS(node.left, max);
        }

        if(node.right != null){
            right = DFS(node.right, max);
        }
        res = res + left + right;
        return res;
    }
}
/*
    TC: O(n), SC: O(h)
*/