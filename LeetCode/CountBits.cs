//给定非负整数num，计算从0到num个数中二进制1的个数
//要求时间和空间复杂度为O(n)
public class Solution {
    public int[] CountBits(int num) {
        int[] ret = new int[num + 1];

        for (int i = 1; i < num; i ++)
        {
            ret[i] = ret[i >> 1];
            if (i % 2 == 1) ret[i]++;
        }

        return ret;
    }
}