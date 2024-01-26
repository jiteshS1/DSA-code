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
    public TreeNode InvertTree(TreeNode root) {
        if(root == null){
            return null;
        }else{
            //Switch nodes
            TreeNode temp  = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);
            return root;
        }
    }
}
/*
- root can be null
Rec. Fun. (node)
    if node is null
        return null
    if node.left 
        temp = node.left
        node.left = node.r
        node.r = temp;
    rec(node.l);
    rec(node.r);

- r(node)
-   r(l)
    r(r)

Better solution (Iterative) to use stack or queue rather doing recursive calls as it will fill application stack.
https://leetcode.com/problems/invert-binary-tree/solutions/62707/straightforward-dfs-recursive-iterative-bfs-solutions/

*/