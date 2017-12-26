using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBridge : MonoBehaviour {
    private void Start()
    {
        DirectX dx=new DirectX();
        Sphere s = new Sphere(dx);
        s.Draw();
        Cube c = new Cube(dx);
        c.Draw();

        OpenGL ogl = new OpenGL();
        Cylinder cy = new Cylinder(ogl);
        cy.Draw();

    }

}

//渲染引擎接口
public abstract class RenderEngine {
    public abstract void Render(string renderName);
}

//DirectX引擎
public class DirectX : RenderEngine {
    public override void Render(string renderName)
    {
        DirectXRender(renderName);
    }

    void DirectXRender(string renderName) {
        Debug.Log("通过DirectX来渲染："+renderName);
    }
}
//OpenGL引擎
public class OpenGL : RenderEngine {
    public override void Render(string renderName)
    {
        OpenGLRender(renderName);
    }
    void OpenGLRender(string renderName) {
        Debug.Log("通过OpenGL来渲染：" + renderName);
    }
}
//让调用者来选择渲染引擎
public abstract class IShape {
    public RenderEngine m_renderEngine = null;
    public IShape(RenderEngine tmpRE) {
        m_renderEngine = tmpRE;
    }
    public abstract void Draw();
}

public class Sphere : IShape {
    public Sphere(RenderEngine re):base(re) {

    }
    public override void Draw()
    {
        m_renderEngine.Render("Sphere");
    }
}

public class Cube : IShape {
    public Cube(RenderEngine re):base(re) {

    }
    public override void Draw()
    {
        m_renderEngine.Render("Cube");
    }
}

public class Cylinder : IShape {
    public Cylinder(RenderEngine re):base(re) {

    }
    public override void Draw()
    {
        m_renderEngine.Render("Cylinder");
    }
}