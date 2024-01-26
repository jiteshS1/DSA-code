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
    public int MaxDepth(TreeNode root) {
        return FindDepth(root, 0);
    }
    public int FindDepth(TreeNode node, int h){
        if(node==null)
            return h;
        else{
            h++;
            return System.Math.Max(FindDepth(node.left, h), FindDepth(node.right, h));
        }

    }
}
/*
Call recursive MaxDepth for left & right subtree
    if no child then return h
    max of hight if left & right;

------------Better Approach----------
if (root == null)
        {
            return 0;
        }
        else 
        {
            return Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
        }

*/