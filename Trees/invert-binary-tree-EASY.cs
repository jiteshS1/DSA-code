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
        //Declaring variables
        var qu = new Queue<NodeDet>();
        
        //Check if there is any node
        if(root == null)
            return root;

        //Push root node in queue
        qu.Enqueue(new NodeDet(root, null, false));

        //Loop till queue is not empty
        while(qu.Count > 0){
            int count = qu.Count;
            int curCount = 0;
            
            //Pop given count element from queue
            while(curCount < count){
                var nodeDet = qu.Dequeue();
                
                //Add child node if present
                if(nodeDet.node.left != null){
                    qu.Enqueue(new NodeDet(nodeDet.node.left, nodeDet.node, true));
                }
                if(nodeDet.node.right != null){
                    qu.Enqueue(new NodeDet(nodeDet.node.right, nodeDet.node, false));
                }

                //Swap node if it not root node
                if(nodeDet.parent != null){
                    if(nodeDet.isLeft){
                        nodeDet.parent.right = nodeDet.node; 
                        if(nodeDet.parent.left == nodeDet.node)
                            nodeDet.parent.left = null;
                    }
                    else
                    {
                        nodeDet.parent.left = nodeDet.node;
                        if(nodeDet.parent.right == nodeDet.node)
                            nodeDet.parent.right = null;
                    }
                }
                curCount++;
            }
        }

        return root;
    }
}
public class NodeDet
{
    public TreeNode node;
    public TreeNode parent;
    public bool isLeft;
    public NodeDet(TreeNode node, TreeNode parent, bool isLeft){
        this.node = node;
        this.parent = parent;
        this.isLeft = isLeft;
    }
}
/*
[(7, 4, f)]
- Push root in queue
- Loop till stack is empty
    - Get count from stack
        - Pop given count elements from stack
            - if left==true, Assign node as left
            - else assign node as right of the parent

            - Push pop node child in stack even if it is null

*/