using System;
using System.Collections.Generic;

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Create adjacency list and in-degree array
        var adjList = new List<int>[numCourses];
        var inDegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++) {
            adjList[i] = new List<int>();
        }
        
        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int pre = prereq[1];
            adjList[pre].Add(course);
            inDegree[course]++;
        }
        
        // Initialize queue and add all nodes with in-degree 0
        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        var res = new List<int>();
        
        while (queue.Count > 0) {
            int node = queue.Dequeue();
            res.Add(node);
            
            // Reduce the in-degree of neighboring nodes
            foreach (int neighbor in adjList[node]) {
                inDegree[neighbor]--;
                // If in-degree becomes 0, add it to the queue
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        // If result list size is not equal to number of courses, return empty array
        if (res.Count != numCourses) {
            return new int[0];
        }
        
        return res.ToArray();
    }
}
/*
    TC, SC: O(V+E)
*/