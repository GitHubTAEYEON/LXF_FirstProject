using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactoryMethod : MonoBehaviour {
    private void Start()
    {
        #region Debug一：
        Creater a = new ProductACreater();
        a.FactoryMethod();

        Creater b = new ProductBCreater();
        b.FactoryMethod();
        #endregion
        #region Debug二：
        Type_Creater tc = new Type_Creater();

        tc.FactoryMethod(1);
        tc.FactoryMethod(2);
        tc.FactoryMethod(3);
        #endregion
        #region Debug三：
        Generic_Creater<ProductA> gcA = new Generic_Creater<ProductA>();
        gcA.FactoryMethod();

        Generic_Creater<ProductB> gcB = new Generic_Creater<ProductB>();
        gcB.FactoryMethod();
        #endregion 
        Creater_Inteface ci = new Creater_Inteface();

        ci.CreaterMethod<ProductA>();
        ci.CreaterMethod<ProductB>();
    }
}
#region  方式一：
//建造者
public abstract class Creater {
    public abstract Product FactoryMethod();
}
//产物A的建造者
public class ProductACreater : Creater {
    public ProductACreater() {
        Debug.Log("产物A的建造者");
    }
    public override Product FactoryMethod()
    {
        return new ProductA();
    }
}
//产物B的建造者
public class ProductBCreater : Creater {
    public ProductBCreater() {
        Debug.Log("产物B的建造者");
    }
    public override Product FactoryMethod()
    {
        return new ProductB();
    }
}
#endregion
#region 方式二：
//类型建造者
public abstract class TypeCreater
{
    public abstract Product FactoryMethod(int Type);
}
//类型建造者执行
public class Type_Creater : TypeCreater
{
    public Type_Creater()
    {
        Debug.Log("类型建造执行者");
    }
    public override Product FactoryMethod(int Type)
    {
        switch (Type)
        {
            case 1:
                return new ProductA();
            case 2:
                return new ProductB();
            default:
                Debug.Log("Type[" + Type + "]无法生产");
                break;
        }
        return null;
    }
}
#endregion
#region 方法三:
//泛型建造者
public class Generic_Creater<T>where T:Product,new() {
    public Generic_Creater() {
        Debug.Log("泛型建造者是[" + typeof(T) + "]的建造者");
    }
    public Product FactoryMethod() {
        return new T();
    }
}
#endregion
//使用接口来实现泛型方法而不是泛型类来选择要生产的产品
interface CreaterInterface {
    Product CreaterMethod<T>() where T : Product, new();
}
//实现接口的建造者类
public class Creater_Inteface : CreaterInterface {
    public Creater_Inteface() {
        Debug.Log("建造者：CreaterInterface");
    }
    public Product CreaterMethod<T>() where T : Product, new() {
        return new T();
    }
}
//产物
public abstract class Product {

}
//产物A
public class ProductA : Product {
    public ProductA() {
        Debug.Log("建造出ProductA");
    }
}
//产物B
public class ProductB : Product {
    public ProductB() {
        Debug.Log("建造出ProductB");
    }
}



