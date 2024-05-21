public class Solution {
    public int MaxProfit(int[] prices) {
        return DFS(0, true, prices, new Dictionary<(int, bool), int>());
    }
    public int DFS(int i, bool buy, int[] prices, Dictionary<(int, bool), int> cache){
        if(i >= prices.Length)
            return 0;

        if(cache.ContainsKey((i, buy)))
            return cache[(i, buy)];
        
        if(buy)
        {
            int buyProfit = DFS(i+1, false, prices, cache) - prices[i];
            int cooldown = DFS(i+1, true, prices, cache);
            int profit = Math.Max(buyProfit, cooldown);
            cache.Add((i, buy), profit);
            return profit;
        }else{
            int sellProfit = DFS(i+2, true, prices, cache) + prices[i];
            int cooldown = DFS(i+1, false, prices, cache);
            int profit = Math.Max(sellProfit, cooldown);
            cache.Add((i, buy), profit);
            return profit;
        }
    }
}
/*
TC, SC: O(n)
- Cooldown is always an option
#DFS(i, buy)
- If I am out of bound
    return 0
- Check in cache if it is already computed

- If buy is true //Can buy
    - int profit = DFS(i+1, false) - price[i] //1st option - Buy
    - int cooldown = DFS(i+1, true) //2nd option cooldown
    - Store result in cache max(profit, cooldown)
- else //Can sell 
    - int sell = DFS(i+2, false) + price[i] //1st option - Sell
    - int cooldown = DFS(i+1, true) //2nd option cooldown
    - Store result in cache max(profit, cooldown)


*/