
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerCurrentQuestText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI PlayerStickText;
    public TextMeshProUGUI PlayerSugarText;
    public TextMeshProUGUI PlayerMoneyText;
    public TextMeshProUGUI PlayerAdBonus1Text;
    public TextMeshProUGUI PlayerAdBonus2Text;
    public TextMeshProUGUI PlayerChainLevelText;
    public TextMeshProUGUI PlayerChainPriceText;
    public TextMeshProUGUI PlayerChainPercentText;

    private string _playerCurrentQuest;
    private int _playerLevelNum;
    private int _playerStickNum;
    private int _playerSugarNum;
    private int _playerMoneyNum;
    private int _playerAdBonus1Num;
    private int _playerAdBonus2Num;
    private int _playerChainLevelNum;
    private int _playerChainPriceNum;
    private int _playerChainPercentNum;


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
        _playerAdBonus1Num = Player.Instance.AdBonus1;
        _playerAdBonus2Num = Player.Instance.AdBonus2;
        _playerChainLevelNum = Player.Instance.ChainBouns;
        _playerChainPriceNum = Player.Instance.ChainBouns * 1000;
        _playerChainPercentNum = 100 - Player.Instance.ChainBouns * 10;

        PlayerLevelText.text = _playerLevelNum.ToString();
        PlayerStickText.text = _playerStickNum.ToString();
        PlayerSugarText.text = _playerSugarNum.ToString();
        PlayerMoneyText.text = _playerMoneyNum.ToString();
        PlayerAdBonus1Text.text = _playerAdBonus1Num.ToString();
        PlayerAdBonus2Text.text = _playerAdBonus2Num.ToString();
        PlayerChainLevelText.text = _playerChainLevelNum.ToString();
        PlayerChainPriceText.text = _playerChainPriceNum.ToString();
        PlayerChainPercentText.text = _playerChainPercentNum.ToString();
    }

}
