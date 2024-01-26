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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p!=null && q!=null){
            bool lRes = IsSameTree(p.left, q.left);
            bool rRes = IsSameTree(p.right, q.right);
            if(lRes==true && rRes==true && p.val==q.val)
                return true;
            else 
                return false;
        }else if(p==null && q==null)
            return true;
        else 
            return false;
    }
}
/*
1st approach:
- 1st BT
    Save all values in array from left to right and null where no node is present.
    O(n) to store in an array
    O(m) to check next BT.

#Rec func: O(n)
Rec(p, q)
    if p & q are not null
        lRes = Call Rec(p.left, q.left)
        rRes = Call Rec(p.right, q.right)
        if(lRes & rRes && p.val == q.val)
            return true;
        else return false;
    else if p & q both null
        return true;
    else return false;

*/