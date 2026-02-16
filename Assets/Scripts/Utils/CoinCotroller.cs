using UnityEngine;

public class CoinCotroller : MonoBehaviour
{
    public static CoinCotroller Instance; // làm cho biến Instance trở thành một biến tĩnh
    private void Awake()
    {
        Instance = this; // Gán biến Instance trong phương thức Awake
    }

    public int currentCoins; // Số lượng xu hiện tại của người chơi
    public CoinItem coin; // Tham chiếu đến prefab của CoinItem
    public void AddCoin(int coinsToAdd)
    {
        currentCoins += coinsToAdd; // Thêm số lượng xu vào tổng số xu hiện tại
        UIController.Instance.UpdateCoins(); // Cập nhật giao diện người dùng để hiển thị số xu mới
    }
    public void DropCoin(Vector3 position, int coinValue)
    {
        CoinItem newCoin = Instantiate(coin, position + new Vector3(.2f, .1f, 0f), Quaternion.identity); // Tạo một bản sao của CoinItem tại vị trí cụ thể
        newCoin.coinValue = coinValue; // Gán giá trị xu cho CoinItem mới tạo
        newCoin.gameObject.SetActive(true); // Kích hoạt CoinItem mới tạo
    }
}
