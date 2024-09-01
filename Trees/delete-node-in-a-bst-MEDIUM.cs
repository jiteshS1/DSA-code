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
    public TreeNode DeleteNode(TreeNode root, int key) {
        // Edge case
        if (root == null)
            return root;

        // Declaring variables
        TreeNode parentNode = null, currentNode = root, targetNode = null;
        bool isLeftChild = false;

        // Search node
        while (currentNode != null) {
            if (currentNode.val == key) {
                targetNode = currentNode;
                break;
            }
            parentNode = currentNode;
            if (key < currentNode.val) {
                currentNode = currentNode.left;
                isLeftChild = true;
            } else {
                currentNode = currentNode.right;
                isLeftChild = false;
            }
        }

        // Check if target node is found
        if (targetNode == null)
            return root;

        //If node is leaf node
        if(targetNode.left == null && targetNode.right == null){
            if(parentNode != null){
                if(isLeftChild){
                    parentNode.left = null;
                }else
                    parentNode.right = null;
                return root;
            }
            else
                return null;
        }
        TreeNode tempRoot = null;
        //If right child is present
        if(targetNode.right != null){
            TreeNode rightMostNode = null;
            //Attach right tree with left subtree right most node
            if(targetNode.left != null){
                //Fetch right most node from left sub-tree
                tempRoot = targetNode.left;
                rightMostNode = targetNode.left;
                while (rightMostNode.right != null) {
                    rightMostNode = rightMostNode.right;
                }
                //Assign right sub-tree to right most node of left tree
                rightMostNode.right = targetNode.right;
            }else{
                //If no left sub-tree is present
                tempRoot = targetNode.right;
            }
        }else{
            //No right sub-tree is present
            tempRoot = targetNode.left;;
        }

        //Attach this temp root node with the parent node 
        if(parentNode != null){
            if(isLeftChild)
                parentNode.left = tempRoot;
            else
                parentNode.right = tempRoot;
            return root;
        }else
        {
            return tempRoot;
        }
    }
}
/*
    TC: O(h), SC: O(1)
*/