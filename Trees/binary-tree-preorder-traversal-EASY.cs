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
    public IList<int> PreorderTraversal(TreeNode root) {
        System.Collections.Generic.Stack<TreeNode> st = new();
        IList<int> list = new List<int>();
        while(root != null || st.Count!=0){
            if(root != null){
                list.Add(root.val);
                st.Push(root.right);
                root = root.left;
            }else{
                root = st.Pop();
            }
        }
        return list;
    }
}
/*
Loop while root  is not null || stack is not empty
    if(root is not null)
        add value in list object
        root.right store in stack
        root = root.left
    else 
        root = pop from stack
    

st: [], [2], [], [null]
node: 1, null, 2, 3 
list: 1, 2 
*/