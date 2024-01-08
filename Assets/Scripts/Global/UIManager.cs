
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerCurrentQuestText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI PlayerStickText;
    public TextMeshProUGUI PlayerSugarText;
    public TextMeshProUGUI PlayerMoneyText;
    private string _playerCurrentQuest;
    private int _playerLevelNum;
    private int _playerStickNum;
    private int _playerSugarNum;
    private int _playerMoneyNum;


    // Update is called once per frame
    private void Update()
    {
        PlayerUISetting();
    }

    private void PlayerUISetting()
    {
        _playerLevelNum = Player.Instance.Level;
        _playerSugarNum = Player.Instance.Sugar;
        _playerStickNum = Player.Instance.Stick;
        _playerMoneyNum = Player.Instance.Money;

        PlayerLevelText.text = _playerLevelNum.ToString();
        PlayerStickText.text = _playerStickNum.ToString();
        PlayerSugarText.text = _playerSugarNum.ToString();
        PlayerMoneyText.text = _playerMoneyNum.ToString();
    }

}
