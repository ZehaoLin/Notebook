/**
 * 二进制中1的个数
 * 题目：输入一个整数，输出该数二进制表示中1的个数
 */
public class Solution {
    public int numberOf1(int n) {//n可正可负
        int count = 0;

        while (n) {
            ++ count;
            n = (n - 1) & n;
        }

        return count;
    }
}