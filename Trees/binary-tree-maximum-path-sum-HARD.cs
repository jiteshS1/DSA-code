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
    int maxPathSum = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        maxPathSum = root.val;
        FindNodeMaxPath(root);
        return maxPathSum;
    }
    public int FindNodeMaxPath(TreeNode node){
        if(node == null) return 0;
        int leftSum = FindNodeMaxPath(node.left);
        int rightSum = FindNodeMaxPath(node.right);
        int max = System.Math.Max(leftSum + node.val, rightSum + node.val);
        max = System.Math.Max(node.val, max);
        //max = System.Math.Max(leftSum + rightSum + node.val, max); 
 
        maxPathSum = System.Math.Max(max, maxPathSum); 
        maxPathSum = System.Math.Max(leftSum + rightSum + node.val, maxPathSum); 
        maxPathSum = System.Math.Max(node.val, maxPathSum); 
        return max;
    }
}
/*
TC: O(n), SC: O(h)
#Recursive method:
- If node null return 0
- leftSum = Call recusive method with left child
- rightSum = Call recusive method with right child
- max of left +node sum & right sum + nodesum
- Update maxPath if max is greter
return max;
*/