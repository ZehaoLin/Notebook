/**
 * 工厂模式
 */

/**
 * 创建接口
 */
public interface Shape {
    void draw();//接口中的所有方法都为public，但在实现的类中需要指定为public
}

/**
 * 创建实现接口的实体类
 */
public class Rectangle implements Shape {

    @Override
    public void draw() {
        System.out.println("Inside Rectangle::draw() method.");
    }
}

public class Square implements Shape {

    @Override
    public void draw() {
        System.out.println("Inside Square::draw() method.");
    }
}

public class Circle implements Shape {

    @Override
    public void draw() {
        System.out.println("Inside Circle::draw() method.");
    }
}

/**
 * 创建一个工厂，生成基于给定信息的实体类对象
 */
public class ShapeFactory {
    //使用getShape方法获取形状类型的对象
    public Shape getShape(String shapeType) {
        if (shapeType == null)
            return null;

         if (shapeType.equalsIgnoreCase("CIRCLE")) {
             return new Circle();
         } else if (shapeType.equalsIgnoreCase("RECTANGLE")) {
             return new Rectangle();
         } else if (shapeType.equalsIgnoreCase("SQUARE")) {
             return new Square();
         }

         return null;
    }
}

/**
 * 使用该工厂，通过传递类型信息来获取实体类对象
 */
public class FactoryPatternDemo {

    public static void main(String[] args) {
        ShapeFactory shapeFactory = new ShapeFactory();

        //通过工厂获取Circle对象，并调用它的draw方法
        Shape shape1 = shapeFactory.getShape("CIRCLE");
        shape1.draw();

        //通过工厂获取Rectangle对象，并调用它的draw方法
        Shape shape2 = shapeFactory.getShape("RECTANGLE");
        shape2.draw();

        //通过工厂获取Square对象，并调用它的draw方法
        Shape shape3 = shapeFactory.getShape("SQUARE");
        shape3.draw();
    }
}