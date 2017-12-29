using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestComposite : MonoBehaviour {
    private void Start()
    {
        IComposite root = new Composite("Root");
        root.Add(new DComponent("DC1"));
        root.Add(new DComponent("DC2"));

        IComposite rootChild1 = new Composite("RootChild1");
        rootChild1.Add(new DComponent("DC1"));
        rootChild1.Add(new DComponent("DC2"));
        root.Add(rootChild1);

        IComposite rootChild2 = new Composite("RootChild2");
        rootChild2.Add(new DComponent("DC1"));
        rootChild2.Add(new DComponent("DC2"));
        rootChild2.Add(new DComponent("DC3"));
        root.Add(rootChild2);

        root.Operation();      
    }
}
//组合接口
public abstract class IComposite {
    public string m_Name;

    public IComposite(string name) {
        m_Name = name;
    }

    //组件执行的方法
    public abstract void Operation();

    //可添添加组件，可为父类的功能
    public virtual void Add(IComposite ic) {
        //如果子类没有继承
        Debug.Log("子类没有继承该方法");
    }
    public virtual void Remove(IComposite ic) {
        Debug.Log("子类没有继承该方法");
    }
    public virtual IComposite GetAllComponet(int index) {
        Debug.Log("子类没有继承该方法");
        return null;
    }
}

//继承组合接口的可添加组件的类
public class Composite : IComposite {
    public List<IComposite> m_Composites;
    public Composite(string cName) : base(cName) {
        m_Name = cName;
        m_Composites = new List<IComposite>();
    }
    public override void Operation()
    {
        Debug.Log("组件的名称为：" + m_Name);
        foreach (IComposite ic in m_Composites) {
            ic.Operation();
        }
    }
    public override void Add(IComposite ic)
    {
        m_Composites.Add(ic);
    }
    public override void Remove(IComposite ic)
    {
        m_Composites.Remove(ic);
    }
    public override IComposite GetAllComponet(int index)
    {
        return m_Composites[index];
    }
}
//继承接口的最底层的组件，不可添加组件
public class DComponent : IComposite {
    public DComponent(string dName) : base(dName) {
        m_Name = dName;
    }
    public override void Operation()
    {
        Debug.Log("最低组件的名称为：" + m_Name);
    }
}
