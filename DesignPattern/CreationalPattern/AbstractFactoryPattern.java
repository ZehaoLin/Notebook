/**
 * 抽象工厂模式
 * 围绕一个超级工厂创建其他工厂 这个超级工厂也就是工厂的工厂
 */

/**
 * 为形状创建一个接口
 */
public interface Shape {
    void draw();
}

/**
 * 创建实现形状接口的实体类
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
 * 为颜色创建一个接口
 */
public interface Color {
    void fill();
}

/**
 * 创建实现颜色接口的实体类
 */
public class Red implements Color {

    @Override
    public void fill() {
        System.out.println("Inside Red::fill() method.");
    }
}

public class Green implements Color {

   @Override
   public void fill() {
      System.out.println("Inside Green::fill() method.");
   }
}

public class Blue implements Color {

   @Override
   public void fill() {
      System.out.println("Inside Blue::fill() method.");
   }
}

/**
 * 完成一级工厂构建，接下来是二级工厂
 */

/**
 * 为Color和Shape对象创建抽象类来获取工厂
 */
public abstract class AbstractFactory {
    abstract Color getColor(String color);
    abstract Shape getShape(String shape);
}

/**
 * 创建拓展了AbstracFactory的工厂类，基于给定的信息生成实体类的对象
 */
public class ShapeFactory extends AbstractFactory {
    
    @Override
    public Shape getShape(String shapeType) {
        if(shapeType == null){
         return null;
        }		
        if(shapeType.equalsIgnoreCase("CIRCLE")) {
            return new Circle();
        } else if(shapeType.equalsIgnoreCase("RECTANGLE")) {
            return new Rectangle();
        } else if(shapeType.equalsIgnoreCase("SQUARE")) {
            return new Square();
        }
        return null;
    }

    @Override
    public Color getColor(String color) {
        return null;
    }
}

public class ColorFactory extends AbstractFactory {
	
   @Override
   public Shape getShape(String shapeType){
      return null;
   }
   
   @Override
   Color getColor(String color) {
      if(color == null){
         return null;
      }		
      if(color.equalsIgnoreCase("RED")){
         return new Red();
      } else if(color.equalsIgnoreCase("GREEN")){
         return new Green();
      } else if(color.equalsIgnoreCase("BLUE")){
         return new Blue();
      }
      return null;
   }
}

/**
 * 创建一个工厂生成器类(超级工厂)，通过传递形状或者颜色信息来获取工厂
 */
public class FactoryProducer {
    public static AbstractFactory getFactory(String choice) {
        if (choice.equalsIgnoreCase("SHAPE")) {
            return new ShapeFactory();
        } else if (choice.equalsIgnoreCase("COLOR")) {
            return new ColorFactory();
        }
    }
}

/**
 * 使用FactoryProducer来获取AbstractFactory，通过传递类型信息来获取实体类的对象
 */
public class AbstractFactoryPatternDemo {
    public static void main(String[] args) {

        //获取形状工厂
        AbstractFactory shapeFactory = FactoryProducer.getFactory("SHAPE");

        //获取形状为Circle的对象
        Shape shape1 = shapeFactory.getShape("CIRCLE");
        //调用Circle的对象
        shape1.draw();

        //获取形状为 Rectangle 的对象
        Shape shape2 = shapeFactory.getShape("RECTANGLE");
        //调用 Rectangle 的 draw 方法
        shape2.draw();

        //获取形状为 Square 的对象
        Shape shape3 = shapeFactory.getShape("SQUARE");
        //调用 Square 的 draw 方法
        shape3.draw();

        //获取颜色工厂
        AbstractFactory colorFactory = FactoryProducer.getFactory("COLOR");

        //获取颜色为 Red 的对象
        Color color1 = colorFactory.getColor("RED");
        //调用 Red 的 fill 方法
        color1.fill();

        //获取颜色为 Green 的对象
        Color color2 = colorFactory.getColor("Green");
        //调用 Green 的 fill 方法
        color2.fill();

        //获取颜色为 Blue 的对象
        Color color3 = colorFactory.getColor("BLUE");
        //调用 Blue 的 fill 方法
        color3.fill();
    }
}