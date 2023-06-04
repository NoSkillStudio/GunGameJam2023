using UnityEngine.UI;
using UnityEngine;

public class MessageChanger : MonoBehaviour
{
    private Animator anim;
    private Text textComponent;

    private void Start()
    {
        anim = GetComponent<Animator>();
        textComponent = GetComponent<Text>();
    }

    public void AddGoal(string goal)
    {
        textComponent.text = "Добавилась новая цель: " + goal;
        anim.SetTrigger("OpenAndClose");
    }

    public void FirstPlayerCompletedGoal(string goal)
    {
        textComponent.text = "Первый игрок выполнил цель: " + goal;
        anim.SetTrigger("OpenAndClose");
    }

    public void SecondPlayerCompletedGoal(string goal)
    {
        textComponent.text = "Второй игрок выполнил цель: " + goal;
        anim.SetTrigger("OpenAndClose");
    }

    public void ChangeGameRuleForFirstPlayer(string rule)
    {
        textComponent.text = "Правила изменились для первого игрока: " + rule;
        anim.SetTrigger("OpenAndClose");
    }

    public void ChangeGameRuleForSecondPlayer(string rule)
    {
        textComponent.text = "Правила изменились для второго игрока: " + rule;
        anim.SetTrigger("OpenAndClose");
    }

    public void ChangeGameRuleForAllPlayers(string rule)
    {
        textComponent.text = "Правила изменились для всех игроков: " + rule;
        anim.SetTrigger("OpenAndClose");
    }

    public void ShowMessage(string message)
    {
        textComponent.text = message;
        anim.SetTrigger("OpenAndClose");
    }
}
