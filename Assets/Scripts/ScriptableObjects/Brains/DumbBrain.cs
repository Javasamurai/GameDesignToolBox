using UnityEngine;
namespace RaraGames
{
    [CreateAssetMenu(fileName = "DumbBrain", menuName = "Level Designer ToolBox/DumbBrain", order = 0)]

    public class DumbBrain : ActorBrain
    {

        public override void Think(SmartActors thinker)
        {
            // Dumb brain cant think
        }
    }
}