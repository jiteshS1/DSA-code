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
    public IList<int> InorderTraversal(TreeNode root) {
        System.Collections.Generic.Stack<TreeNode> st = new();
        IList<int> res = new List<int>();
        while(root!=null || st.Count!=0){
            if(root != null){
                st.Push(root);
                root = root.left;
            }else{
                root = st.Pop();
                res.Add(root.val);
                root = root.right;
            }
        }
        return res;
    }
}
/*
Loop will node !=null || stack is not empty
    if node is not null
        store node in st
        node = node.left
    else 
        temp = pop from stack
        add temp in list
        node = temp.right;
*/