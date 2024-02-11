public class Solution {
    System.Collections.Generic.PriorityQueue<int, int> q = new System.Collections.Generic.PriorityQueue<int, int>(new IntComparer());
    public int LastStoneWeight(int[] stones) {
        for(int i=0; i<stones.Length; i++){
            q.Enqueue(stones[i], stones[i]);
        }
        return SmashStones();
    }
    public int SmashStones(){
        if(q.Count==0){
            return 0;
        }else if(q.Count==1){
            return q.Dequeue();
        }else {
            int x, y;
            y = q.Dequeue();
            x = q.Dequeue();
            if(x!=y){
                q.Enqueue(y-x, y-x);
            }
            return SmashStones();
        }
    }
}
public class IntComparer: IComparer<int>{
    public int Compare(int x, int y){
        return y.CompareTo(x);
    }
}
/*
Can use max heap with priority queue with reverse comparison
- Need two largest integers x & y 
    - If available
        then update y value  = y - x;
        remove x from stones array
    - Check if one at least one is available and return value
        - if not return 0 

------------Max Heap can be generated using array too------------
public class MaxHeap
{
    public int[] heap;
    private int size;
    private int capacity;

    public MaxHeap(int capacity)
    {
        this.capacity = capacity;
        this.size = 0;
        this.heap = new int[capacity];
    }

    public void Insert(int value)
    {
        if (size == capacity)
        {
            return;
        }

        heap[size] = value;
        size++;

        HeapifyUp(size - 1);
    }

    public int ExtractMax()
    {
        if (size == 0)
        {
            return -1; 
        }

        int max = heap[0];
        heap[0] = heap[size - 1];
        size--;

        HeapifyDown(0);

        return max;
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;
        while (index > 0 && heap[index] > heap[parentIndex])
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxIndex = index;

            if (leftChildIndex < size && heap[leftChildIndex] > heap[maxIndex])
                maxIndex = leftChildIndex;

            if (rightChildIndex < size && heap[rightChildIndex] > heap[maxIndex])
                maxIndex = rightChildIndex;

            if (index != maxIndex)
            {
                Swap(index, maxIndex);
                index = maxIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
*/