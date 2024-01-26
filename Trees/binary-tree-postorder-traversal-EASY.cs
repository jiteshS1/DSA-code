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
    IList<int> ls = new List<int>();
    public IList<int> PostorderTraversal(TreeNode root) {
        GetPostorderTraversal(root);
        return ls;
    }
    public void GetPostorderTraversal(TreeNode node){
        if(node!=null){
            GetPostorderTraversal(node.left);
            GetPostorderTraversal(node.right);
            ls.Add(node.val);
        }
    }
}
/*
#Iterative Approach with Linked list:
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        System.Collections.Generic.LinkedList<int> ll = new();
        System.Collections.Generic.Stack<TreeNode> st = new();
        while(root != null || st.Count != 0){
            if(root != null){
                ll.AddFirst(root.val);
                st.Push(root);
                root = root.right;
            }else{
                root = st.Pop();
                root = root.left;
            }
        }
        return ll.ToList();
    }
}
*/