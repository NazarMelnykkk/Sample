using UnityEngine ;

namespace WheleOfFortune
{
    [CreateAssetMenu(menuName = "Config/WheelPiece")]
    public class WheelPiece : ScriptableObject
    {
        public UnityEngine.Sprite Icon;
        public string Label;

        [Tooltip("Reward multiplier")] public int Multiplier;
    }
}
