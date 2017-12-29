using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuilder : MonoBehaviour {
    private void Start()
    {
        Director dA = new Director(new BuilderA());
        dA.BuildePartWay();
        dA.GetWholeProduct().ShowPartOfProduct();

        Director dB = new Director(new BuilderB());
        dB.BuildePartWay();
        dB.GetWholeProduct().ShowPartOfProduct();
    }
}

//管理类
public class Director {
    BuilderProduct m_builderProduct=new BuilderProduct();
    Builder m_builder;
    public Director(Builder b) {
        m_builder = b;
    }
    public void BuildePartWay() {
        m_builder.BuilderPartA(m_builderProduct);
        m_builder.BuilderPartB(m_builderProduct);
    }
    //获得成品
    public BuilderProduct GetWholeProduct() {
        return m_builderProduct;
    }
}

public abstract class Builder {
    public abstract void BuilderPartA(BuilderProduct pb);
    public abstract void BuilderPartB(BuilderProduct pb); 
}
//建造者A
public class BuilderA : Builder {
    public override void BuilderPartA(BuilderProduct pb)
    {
        pb.AddPart("来自建造者A所建造的A部分");
    }
    public override void BuilderPartB(BuilderProduct pb)
    {
        pb.AddPart("来自建造者A所建造的B部分");
    }
}
//建造者B
public class BuilderB : Builder {
    public override void BuilderPartA(BuilderProduct pb)
    {
        pb.AddPart("来自建造者B所建造的A部分");
    }
    public override void BuilderPartB(BuilderProduct pb)
    {
        pb.AddPart("来自建造者B所建造的B部分");
    }
}

//需要建造的产品
public class BuilderProduct {
    public List<string> productParts;
    public BuilderProduct() {
        productParts = new List<string>();
    }
    //添加建造的部分
    public void AddPart(string part) {
        productParts.Add(part);
    }
    //显示产品内容
    public void ShowPartOfProduct() {
        foreach (string part in productParts) {
            Debug.Log(part);
        }
    }

}
