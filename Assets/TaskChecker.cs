using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public static Toggle Task1;
    public static Toggle Task2;
    public static Toggle Task3;
    public static Toggle Task4;
    public Toggle[] TaskList = { Task1, Task2, Task3, Task4 };

    public void checkTask(int task)
    {
        TaskList[task].isOn = true;
    }
}
