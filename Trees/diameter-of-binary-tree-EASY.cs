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
    int max=0;
    public int DiameterOfBinaryTree(TreeNode root) {
        CalculateDiameter(root);
        return max;
    }
    private int CalculateDiameter(TreeNode root) {
        if (root == null) return 0;

        int leftDepth = CalculateDiameter(root.left);
        int rightDepth = CalculateDiameter(root.right);

        // Update the max diameter based on the current node
        max = System.Math.Max(max, leftDepth + rightDepth);

        // Return the depth of the current subtree
        return 1 + System.Math.Max(leftDepth, rightDepth);
    }
}