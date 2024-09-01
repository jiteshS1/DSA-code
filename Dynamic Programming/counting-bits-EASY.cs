public class Solution {
    public int[] CountBits(int n) {
        int[] cache = new int[n+1];

        //Initilaize array to -1
        for(int i=0; i<cache.Length; i++){
            cache[i] = -1;
        }

        for(int i=0; i<=n; i++){
            CountBits(i, 0, ref cache);
        }

        return cache;
    }
    public int CountBits(int n, int bits, ref int[] cache){
        if(cache[n] != -1){
            //Return from cache
            return cache[n];
        }
        if(n==0)
        {
            //Update bits in cache
            cache[n] =  bits;
            return cache[n]; 
        }
        
        int res = CountBits(n/2, bits + n%2, ref cache);
        cache[n] = res + n%2;
        return cache[n]; 
    }
}
/*
    TC, SC: O(n)

    Using DP:
    
    public class Solution {
    public int[] CountBits(int n) {
        int[] dp = new int[n+1];
        dp[0] = 0;
        for(int i=1; i<=n; i++)
        {
            if(i%2==1)
                dp[i] = dp[i/2]+1;
            else
                dp[i] = dp[i/2];
        }
        return dp;
    }
}
*/