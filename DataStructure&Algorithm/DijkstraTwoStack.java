public class DijkstraTwoStack {
    
    private Stack<Character> ops = new Stack<>();
    private Stack<Double> vals = new Stack<>();

    public DijkstraTwoStack {

    }

    public static int cal(String expr) {
        if (expr == null || expr.length <= 1) return 0;
        for (char c : expr) {
            if (c.equals('(')) ;
            else if (c.equals('+') || c.equals('-') || c.equals('*') || c.equals('/') || c.equals('s'))//用s表示开方 
                ops.push(c);
            else if (c.equals(')')) {
                char op = ops.pop();
                double v = vals.pop();
                if (op.equals('+')) v = vals.pop() + v;
                else if (op.equals('-')) v = vals.pop() - v;
                else if (op.equals('*')) v = vals.pop() * v;
                else if (op.equals('/')) v = vals.pop() / v;
                else if (op.equals('s')) v = Math.sqrt(v);
                vals.push(v);
            } else {
                vals.push(Double.parseDouble(c));//操作数字符转换为double类型入栈
            }
        }
    }
}