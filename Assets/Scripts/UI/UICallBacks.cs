using System;

namespace RaraGames
{
    public class UICallBacks {
        Action<Actor> onGameItemSelected;
        Action<Actor> onGameItemDicarded;
        Action<Actor> onGameItemDropped;
    }
}
