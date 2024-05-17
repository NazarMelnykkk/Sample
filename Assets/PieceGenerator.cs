using UnityEngine;
using UnityEngine.UI;


namespace WheleOfFortune
{
    public class PieceGenerator : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private WheelOfFortuneReferences _wheelOfFortuneReferences;


        [Header("References")]
        [SerializeField] private Transform _pickerWheelTransform;

        [SerializeField] private GameObject _wheelPiecePrefab;
        [SerializeField] private Transform _wheelPiecesParent;

        [SerializeField] private Transform _wheelCircle;

        [SerializeField] private GameObject _linePrefab;
        [SerializeField] private Transform _linesParent;

        [Header("Pieces")]
        private Vector2 _pieceMinSize = new Vector2(81f, 146f);
        private Vector2 _pieceMaxSize = new Vector2(144f, 213f);

        [HideInInspector] public int PiecesMin = 2;
        [HideInInspector] public int PiecesMax = 12;

        private float _pieceAngle;
        private float _halfPieceAngle;
        public void Generate()
        {
            _pieceAngle = 360f / _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length;
            _halfPieceAngle = _pieceAngle / 2f;

            RectTransform rectTransform = _wheelPiecePrefab.transform.GetChild(0).GetComponent<RectTransform>();
            float pieceWidth = Mathf.Lerp(_pieceMinSize.x, _pieceMaxSize.x, 1f - Mathf.InverseLerp(PiecesMin, PiecesMax, _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length));
            float pieceHeight = Mathf.Lerp(_pieceMinSize.y, _pieceMaxSize.y, 1f - Mathf.InverseLerp(PiecesMin, PiecesMax, _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length));
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pieceWidth);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pieceHeight);

            for (int i = 0; i < _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length; i++)
            {
                DrawPiece(i);
            }
        }

        private void DrawPiece(int index)
        {
            WheelPiece piece = _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces[index];
            Transform pieceTrns = InstantiatePiece().transform.GetChild(0);

            pieceTrns.GetChild(0).GetComponent<Image>().sprite = piece.Icon;
            pieceTrns.GetChild(1).GetComponent<Text>().text = piece.Label;
            pieceTrns.GetChild(2).GetComponent<Text>().text = piece.Multiplier.ToString();

            Transform lineTrns = Instantiate(_linePrefab, _linesParent.position, Quaternion.identity, _linesParent).transform;
            lineTrns.RotateAround(_wheelPiecesParent.position, Vector3.back, (_pieceAngle * index) + _halfPieceAngle);

            pieceTrns.RotateAround(_wheelPiecesParent.position, Vector3.back, _pieceAngle * index);
        }

        private GameObject InstantiatePiece()
        {
            return Instantiate(_wheelPiecePrefab, _wheelPiecesParent.position, Quaternion.identity, _wheelPiecesParent);
        }

        public WheelPiece GetSelectedPiece()
        {
            float totalRotation = _wheelCircle.rotation.eulerAngles.z + _pieceAngle / 2;
            float normalizedRotation = (totalRotation % 360 + 360) % 360;
            int selectedPieceIndex = Mathf.FloorToInt(normalizedRotation / _pieceAngle);

            return _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces[selectedPieceIndex];
        }

        public float GetPieceAngle()
        {
            return _pieceAngle;
        }

        public void ChangeSize()
        {
            _pickerWheelTransform.localScale = new Vector3(_wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelSize, _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelSize, 1f);

            if (_wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length > PiecesMax || _wheelOfFortuneReferences.WheelOfFortuneSettingController.WheelPieces.Length < PiecesMin)
            {
                Debug.LogError("[PickerWheel] pieces length must be between " + PiecesMin + " and " + PiecesMax);
            }
        }
    }
    

}
