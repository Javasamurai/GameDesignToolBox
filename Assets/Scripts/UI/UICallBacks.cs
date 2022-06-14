using System;

namespace RaraGames
{
    public class UICallBacks {
        public static Action onGameOver;
        public static Action<int> onCoinCollected;
        public static Action<float> onHealthDown;
        public static Action onFlagCollected;
    }
}
