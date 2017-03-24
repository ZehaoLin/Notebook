/**
 * 斐波那契数列
 */
public class Solution {
    public long long fibonacci(int n) {
        if (n < 0) return 0;

        int[2] result = {0, 1};
        if (n < 2) {
            return result[n];
        }

        long long fibNminusOne = 1;
        long long fibNminusTwo = 2;
        long long fibN = ;
        for (int i = 0; i < n; ++i) {//动态规划 
            fibN = fibNminusOne + fibNminusTwo;
            fibNminusTwo = fibNminusOne;
            fibNminusOne = fibN;
        }

        return fibN;
    }
}