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
    
    public bool IsBalanced(TreeNode root) {
        return CheckNode(root).bal;
    }
    public Result CheckNode(TreeNode node){
        if(node==null) return new Result(true, 0);
        
        var left = CheckNode(node.left);
        var right = CheckNode(node.right);

        if(left.bal==true 
        && right.bal==true 
        && System.Math.Abs(left.h-right.h)<=1){
            return new Result(true, System.Math.Max(left.h, right.h)+1);
        }else{
            return new Result(false, 0);
        }
    }
    public class Result{
        public bool bal;
        public int h;
        public Result(bool bal, int h){
            this.h = h;
            this.bal = bal;
        }
    }
}
/*
Better approach to use below return type rather then class object.
public (int h, bool balanced) height(TreeNode node)
return (0, true);

*/