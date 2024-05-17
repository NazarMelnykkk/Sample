using UnityEngine ;

namespace WheleOfFortune
{
    [System.Serializable]
    public class WheelPiece
    {
        public UnityEngine.Sprite Icon;
        public string Label;

        [Tooltip("Reward multiplier")] public int Multiplier;
    }
}
