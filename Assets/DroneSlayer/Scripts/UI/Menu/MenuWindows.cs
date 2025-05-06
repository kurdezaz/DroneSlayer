using UnityEngine;

namespace DroneSlayer.UI.Menu
{
    public class MenuWindows : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}