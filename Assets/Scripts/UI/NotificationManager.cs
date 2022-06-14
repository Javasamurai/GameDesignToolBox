using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RaraGames
{
    public class NotificationManager : MonoBehaviour {
        [SerializeField]
        TextMeshProUGUI notificationText;

        public void ShowNotification(string notification) {
            notificationText.text = notification;
        }
    }
}