public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int[] parent = new int[edges.Length+1];
        int[] size = new int[edges.Length+1];
        int[] res= new int[2];
        
        //Initialize parent & size array
        for(int i=1; i<edges.Length; i++){
            parent[i] = i;
            size[i] = 1;
        }

        for(int i=0; i<edges.Length; i++){
            int u = edges[i][0],
                v = edges[i][1];
            
            int pu = GetUltimateParent(u, parent),
                pv = GetUltimateParent(v, parent); 
            //Check if u & v nodes are already in one set
            if(pu == pv)
            {
                res[0] = u;
                res[1] = v;
                continue;
            }

            if(size[pu]==size[pv] || size[pu] > size[pv]){
                //Connect v node with u
                parent[pv] = pu;
                size[pv] += size[pu];
            }else{
                //Connect u node with v
                parent[pu] = pv;
                size[pu] += size[pv];
            }
        }

        return res;
    }
    public int GetUltimateParent(int node, int[] parent){
        if(parent[node]==node)
            return node;
        else
        {
            int pNode = GetUltimateParent(parent[node], parent);
            parent[node] = pNode;
            return pNode;
        }
    }
}
/*
    TC: O(E + log h), SC: O(E)
*/