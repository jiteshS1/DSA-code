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
    List<int> inorder = new List<int>();
    public bool IsValidBST(TreeNode root) {
        Inorder(root);

        if(inorder.Count() == 0) return false;

        int prev = inorder[0];
        for(int i=1; i< inorder.Count(); i++){
            if(prev < inorder[i]){
                prev = inorder[i];
            }else
                return false;
        }
        return true;
    }
    public void Inorder(TreeNode node){
        if(node == null) return;
        
        if(node.left != null || node.right != null){
            Inorder(node.left);
            inorder.Add(node.val);
            Inorder(node.right);
        }else{
            inorder.Add(node.val);
        }
        
    }
}
/*
TC, SC: O(n)
- Generate inorder traversal - O(n)
- Check if array values are sorted - O(n)

#Inorder function:
- If node has left
    - Call inorder function on left node
    - add node value in array
    - Call inorder function on right node
- else
    add node value in array

#
---------------------Iterative solution-----------------------
public boolean isValidBST(TreeNode root) {
   if (root == null) return true;
   Stack<TreeNode> stack = new Stack<>();
   TreeNode pre = null;
   while (root != null || !stack.isEmpty()) {
      while (root != null) {
         stack.push(root);
         root = root.left;
      }
      root = stack.pop();
      if(pre != null && root.val <= pre.val) return false;
      pre = root;
      root = root.right;
   }
   return true;
}


*/