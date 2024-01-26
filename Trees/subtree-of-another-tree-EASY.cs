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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        System.Collections.Generic.Queue<TreeNode> q =new();
        q.Enqueue(root);
        while(q.Count != 0){
            var node = q.Dequeue();
            if(node.left!=null)
                q.Enqueue(node.left);
            if(node.right!=null)
                q.Enqueue(node.right);
            if(node.val == subRoot.val)
            {
                //Check sub tree comparison
                var res = IsSameTree(node, subRoot);
                if(res == true)
                    return true;
            }
        }
        return false;
    }
    public bool IsSameTree(TreeNode root1, TreeNode root2){
        if(root1==null && root2==null)
            return true;
        else if(root1!=null && root2!=null && root1.val == root2.val){
            var left = IsSameTree(root1.left, root2.left);
            var right = IsSameTree(root1.right, root2.right);
            if(left==true && right==true)
                return true;
            else 
                return false;
        }else 
            return false;
    }
}
/*
Store root in Queue
    while queue is not empty
        node  = dequeue 
        Push in queue  if child present
        Check node.val same as root of sub-root?
            if same
                call RecFun to compare trees and return value
                break the loop
            else 
                continue in lop
RecFun() to find sub-root node value using DFS
    if left preset
        Check e

if((root1==null && root2==null) || 
            (root1!=null && root2!=null && root1.val == root2.val))
*/