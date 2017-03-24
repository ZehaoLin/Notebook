/**
 * 数值的整数次方
 * 题目：求base的exponent次方，不使用build-in库
 */
public class Solution {
    public double powerWithUnsignedExponent(double base, int exponent) {
        if (base < 0) return 0;
        if (exponent == 0) return 1;
        else if (exponent == 1) return base;

        double result = powerWithUnsignedExponent(base, exponent >> 1);
        result *= result;
        if (exponent & 01 == 1)
            result *= base;
        
        return result;
    }
}