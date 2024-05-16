using EasyUI.PickerWheelUI;
using UnityEngine;

public class WheelOfFortuneSettingController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private WheelOfFortuneController _wheelOfFortuneController;
    [SerializeField] private PieceGenerator _pieceGenerator;

    [Header("Configuration")]
    [SerializeField][Range(0.2f, 2f)] private float _wheelSize = 1f;

    private float _rotatePower = 1000f;
    private float _stoppingPower = 600f;
    private float _randomizationCoefficient = 100f;

    [Header("Pieces")]
    public WheelPiece[] WheelPieces;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public float GetSize()
    {
        return _wheelSize;
    }

    public void SetSize(float size)
    {

    }

    public WheelPiece[] GetPieces()
    {
        return WheelPieces;
    }

    public void SetPieces()
    {
        
    }

    public void SetRotatePower()
    {

    }

    public float GetRotatePower()
    {
        return _rotatePower;
    }

    public void SetStoppingPower()
    {

    }

    public float GetStoppingPower()
    {
        return _stoppingPower;
    }

    public void SetRandomizationCoefficientr()
    {

    }

    public float GetRandomizationCoefficientr()
    {
        return _randomizationCoefficient;
    }

    private void OnValidate()
    {
        _pieceGenerator.ChangeSize();
    }

}
