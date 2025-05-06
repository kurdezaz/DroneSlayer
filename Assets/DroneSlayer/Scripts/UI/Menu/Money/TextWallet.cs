namespace DroneSlayer.UI.Menu.Money
{
    public class TextWallet : MoneyView
    {
        public override void DisplayValue()
        {
            _textMoney.text = _playerMoney.Money.ToString();
        }
    }
}