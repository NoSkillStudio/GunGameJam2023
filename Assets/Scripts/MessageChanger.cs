using UnityEngine;
using TMPro;

public class MessageChanger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text textComponent;

    [SerializeField] private GameObject endPanel;

    public void AddGoal(string goal)
    {
        textComponent.text = "Добавилась новая цель: " + goal;
        anim.SetTrigger("OpenAndClose");
    }

    public void RemoveGoal(string goal)
    {
        textComponent.text = "Минус одна цель: " + goal;
        anim.SetTrigger("OpenAndClose");
    }

    public void FirstPlayerCompletedGoal(string goal)
    {
        textComponent.text = "Первый игрок выполнил цель: " + goal;
        anim.SetTrigger("OpenAndClose");
        InvokeEnd();
    }

    public void SecondPlayerCompletedGoal(string goal)
    {
        textComponent.text = "Второй игрок выполнил цель: " + goal;
        anim.SetTrigger("OpenAndClose");
        InvokeEnd();
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

    public void End()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void InvokeEnd() => Invoke("End", 2.11f);
}
