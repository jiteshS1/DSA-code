public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }

        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++) {
            // Calculate potential profit if sold on day i
            int potentialProfit = prices[i] - minPrice;

            // Update maxProfit if potentialProfit is greater
            maxProfit = Math.Max(maxProfit, potentialProfit);

            // Update minPrice to be the minimum price encountered so far
            minPrice = Math.Min(minPrice, prices[i]);
        }

        return maxProfit;
    }
}
