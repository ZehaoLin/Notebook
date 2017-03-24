/**
 * 用两个栈实现队列
 */
public class Solution<T> {

    private static Stack<T> stack1 = new Stack<>();//入队
    private static Stack<T> stack2 = new Stack<>();//出队

    public void enqueue(T element) {
        stack1.push(element);
    }

    public T dequeue() {
        if (stack2.isEmpty() == true) {//出队，将stack1中的元素弹出，并且在stack2中入栈
            while (stack1.isEmpty() == false) {
                T data = stack1.pop();
                stack2.push(data);
            }
        }

        if (stack2.isEmpty() == true) {
            throw new Exception("queue is empty.");
        }

        return stack2.pop();        
    }
}