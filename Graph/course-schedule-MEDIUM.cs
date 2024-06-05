public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = new List<int>[numCourses];
        var inDegree = new int[numCourses];

        for(int i=0; i<prerequisites.Length; i++){
            //Increase inDegree
            inDegree[prerequisites[i][1]] += 1;
            if(graph[prerequisites[i][0]] != null)
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);
            else
                graph[prerequisites[i][0]] = new List<int>(){prerequisites[i][1]};
        }

        var queue = new Queue<int>();
        for(int i=0; i<inDegree.Length; i++){
            if(inDegree[i] == 0)
                queue.Enqueue(i);
        }

        var order = new List<int>(); //Topological order
        while(queue.Count()>0){
            var vertex = queue.Dequeue();
            order.Add(vertex);
            var edges = graph[vertex];
            if(edges!=null && edges.Count()>0){
                foreach(var tVertex in edges){
                    inDegree[tVertex] -= 1;
                    if(inDegree[tVertex]==0){
                        queue.Enqueue(tVertex);
                    }
                }
            }
        }
        if(order.Count() != numCourses)
            return false;
        else 
            return true;
    }
}
/*
In above solution I have used Kahn's algorithm.

TC, SC: O(V+E)
*/