/**
    二维数组中的查找
    题目：在一个二维数组中，每一行都按照从左到右递增的顺序排序，
        每一列都按照从上到下递增的顺序排序。请完成一个函数，输入
        这样的一个二维数组和一个整数，判断数组中是否含有该整数。
    思路：从右上角开始缩小范围
 */
public class Solution {
    public boolean find(int[][] nums, int rows, int columns, int number) {
        boolean found = false;

        if (nums.length != null && rows > 0 && columns > 0) {
            int row = 0;
            int column = columns - 1;
            while (row < rows && column >= 0) {
                if (nums[row][column] == number) {
                    found = true;
                    break;
                } else if (nums[row][column] > number) {
                    --column;
                } else {
                    ++row;
                }
            }
        }

        return found;
    }
}