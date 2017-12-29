using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTemplateMethod : MonoBehaviour {
    private void Start()
    {
        TemplateMethod a = new TemplateMethodA();
        a.TemplateWay();

        TemplateMethod b = new TemplateMethodB();
        b.TemplateWay();
    }
}

//模板方法
public abstract class TemplateMethod {
    public void TemplateWay() {
        TemplateWayA();
        TemplateWayB();
    }
    public abstract void TemplateWayA();
    public abstract void TemplateWayB();
}

//一种执行方法
public class TemplateMethodA : TemplateMethod {
    public override void TemplateWayA()
    {
        Debug.Log("执行TemplateMethodA中的TemplateWayA");
    }
    public override void TemplateWayB()
    {
        Debug.Log("执行TemplateMethodA中的TemplateWayB");
    }
}

//另一种执行方法
public class TemplateMethodB : TemplateMethod {
    public override void TemplateWayA()
    {
        Debug.Log("执行TemplateMethodB中的TemplateWayA");
    }
    public override void TemplateWayB()
    {
        Debug.Log("执行TemplateMethodB中的TemplateWayB");
    }
}
