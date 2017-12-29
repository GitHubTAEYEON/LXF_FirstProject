using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommand : MonoBehaviour {
    private void Start()
    {
        CommandManager cm = new CommandManager();
        //建立一个Command重复使用
        Command c = null;

        c = new CommandA(new ReciverA(), "命令A1");
        cm.AddCommand(c);
        c = new CommandA(new ReciverA(), "命令A2");
        cm.AddCommand(c);
        c = new CommandB(new ReciverB(), "命令B1");
        cm.AddCommand(c);

        //执行
        cm.ExecuateCommand();
    }
}
//命令父类
public abstract class Command {
    public Reciver m_Reciver;
    public string m_command;
    public Command(Reciver r,string command) {
        m_Reciver = r;
        m_command = command;
    }
    //执行方法
    public abstract void Execute();
}

//接收到命令执行父类
public abstract class Reciver {
    //执行方法的内容
    public abstract void Action(string command);
}

//执行者A
public class ReciverA : Reciver {
    public override void Action(string command)
    {
        Debug.Log("执行者A所执行的命令：" + command);
    }
}
//执行者B
public class ReciverB : Reciver {
    public override void Action(string command)
    {
        Debug.Log("执行者B所执行的命令：" + command);
    }
}

//命令A与执行者A绑定
public class CommandA : Command {
    public CommandA(ReciverA rA,string cm) : base(rA,cm) {
        m_Reciver = rA;
        m_command = cm;
    }
    public override void Execute()
    {
        m_Reciver.Action(m_command);
    }
}

//命令B与执行者B绑定
public class CommandB : Command {
    public CommandB(ReciverB rb,string cm) : base(rb,cm) {
        m_Reciver = rb;
        m_command = cm;
    }
    public override void Execute()
    {
        m_Reciver.Action(m_command);
    }
}

//命令管理者
public class CommandManager {
    public List<Command> commands = new List<Command>();
    //添加命令
    public void AddCommand(Command c) {
        commands.Add(c);
    }
    //执行命令
    public void ExecuateCommand() {
        foreach (Command c in commands) {
            c.Execute();
        }
    }
}


