using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMediator : MonoBehaviour {

    private void Start()
    {
        ColleagueMediator cm = new ColleagueMediator();

        Colleague1 c1 = new Colleague1(cm);
        Colleague2 c2 = new Colleague2(cm);

        cm.SetColleague1(c1);
        cm.SetColleague2(c2);

        c1.C1Action();
        c2.C2Action();
    }
}

//同事1
public class Colleague1 : Colleague {
    public Colleague1(ColleagueMediator tmpCM) : base(tmpCM) {

    }
    public void C1Action() {
        m_ColleagueMediator.SendMessage(this,"Colleague1完成C1Action方法！");
    }
    public override void Request(string message)
    {
        Debug.Log("Colleague1接受到信息：" + message);
    }
}
//同事2
public class Colleague2 : Colleague {
    public Colleague2(ColleagueMediator tmpCM) : base(tmpCM) {

    }
    public void C2Action() {
        m_ColleagueMediator.SendMessage(this, "Colleague2完成C2Action方法！");
    }
    public override void Request(string message)
    {
        Debug.Log("Colleague2接收到信息：" + message);
    }
}

//同事（平级的功能）
public abstract class Colleague {
    //设置中介者（同事通过中介者联系）
    protected ColleagueMediator m_ColleagueMediator;
    //构造方法
    public Colleague(ColleagueMediator tmpCM) {
        m_ColleagueMediator = tmpCM;
    }
    public abstract void Request(string message);

}
//中介者抽象类
public abstract class Mediator {
    //抽象方法只能出现在抽象累中，抽象方法需要添加abstract关键字，抽象方法在非抽象类中必须实现
    /// <summary>
    /// 发送方法
    /// </summary>
    /// <param name="colleague">谁发送的</param>
    /// <param name="message">发送的信息是什么</param>
    public abstract void SendMessage(Colleague colleague, string message);
}

//中介者
public class ColleagueMediator : Mediator {
    private Colleague1 c1 = null;
    private Colleague2 c2 = null;

    public void SetColleague1(Colleague1 c) {
        c1 = c;
    }

    public void SetColleague2(Colleague2 c) {
        c2 = c;
    }

    public override void SendMessage(Colleague colleague, string message)
    {
        if (colleague == c1)
            c2.Request(message);
        if (colleague == c2)
            c1.Request(message);
    }
}

