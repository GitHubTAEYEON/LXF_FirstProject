using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClassWithCount : MonoBehaviour
{
    private void Start()
    {
        ClassWithCount c1 = new ClassWithCount();
        c1.Operator();
        ClassWithCount c2 = new ClassWithCount();
        c2.Operator();

        c1.Operator();
    }
}

public class ClassWithCount
{
    //static静态变量值为上次执行完之后的值，如果不加Static每次创建的类的m_count都为0；
    protected static int m_count = 0;
    protected bool unEnable = false;

    public ClassWithCount()
    {
        m_count += 1;
        unEnable = (m_count == 1) ? true : false;
        if (unEnable == false) {
            Debug.LogError("当前对象数为[" + m_count + "],超过1个");
        }
    }
    public void Operator() {
        if (unEnable == false)
            return;
        else
            Debug.Log("可执行!");
    }
}
