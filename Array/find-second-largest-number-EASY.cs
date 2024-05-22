import java.util.* ;
import java.io.*; 
public class Solution {
	public static int findSecondLargest(int n, int[] arr) {
		int max=-1, max2=-1;
		if(n>=2)
		{
			max = arr[0];
			max2 = arr[1];
			if(max2 > max)
			{
				max = max2;
				max2 = arr[0];
			}
		}
        //NOTE: I can use Integer.MIN_VALUE an store in max and max2 rather then the above code.
		
        // Write your code here.
		for(int i=2; i<n; i++){
			if(arr[i]>max)
			{
				max2=max;
				max= arr[i];
			}
			else if(arr[i]>max2 && arr[i]<max)
			{
				max2= arr[i];
			}
		}
		if(max==max2)
			return -1;
		else
			return max2;
	}
}