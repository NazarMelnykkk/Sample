﻿using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections.Generic;
using EasyUI.PickerWheelUI;

public class PickerWheel : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ButtonClickedBase _spinningButton;

    [Header("References")]
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Transform _linesParent;

    [Space]
    [SerializeField] private Transform _pickerWheelTransform;
    [SerializeField] private Transform _wheelCircle;
    [SerializeField] private GameObject _wheelPiecePrefab;
    [SerializeField] private Transform _wheelPiecesParent;

    [Space]
    [Header("Sounds")]
    [SerializeField] private List<SoundConfig> _tickSounds;

    [Space]
    [Header("Picker wheel settings")]
    [Range(1, 20)] public int spinDuration = 8;
    [SerializeField][Range(.2f, 2f)] private float wheelSize = 1f;

    [Space]
    [Header("Picker wheel pieces")]
    public WheelPiece[] wheelPieces;

    // Events
    private UnityAction onSpinStartEvent;
    private UnityAction<WheelPiece> onSpinEndEvent;

    private bool _isSpinning = false;

    public bool IsSpinning { get { return _isSpinning; } }

    private Vector2 pieceMinSize = new Vector2(81f, 146f);
    private Vector2 pieceMaxSize = new Vector2(144f, 213f);
    private int piecesMin = 2;
    private int piecesMax = 12;

    private float pieceAngle;
    private float halfPieceAngle;
    private float halfPieceAngleWithPaddings;

    private double accumulatedWeight;
    private System.Random rand = new System.Random();

    private List<int> nonZeroChancesIndices = new List<int>();

    private void OnEnable()
    {
        _spinningButton.OnButtonClick += Spin;
    }

    private void OnDisable()
    {
        _spinningButton.OnButtonClick -= Spin;
    }

    private void Start()
    {
        pieceAngle = 360 / wheelPieces.Length;
        halfPieceAngle = pieceAngle / 2f;
        halfPieceAngleWithPaddings = halfPieceAngle - (halfPieceAngle / 4f);

        Generate();

        CalculateWeightsAndIndices();
        if (nonZeroChancesIndices.Count == 0)
        {
            Debug.LogError("You can't set all pieces chance to zero");
        }
    }

    private void Generate()
    {
        _wheelPiecePrefab = InstantiatePiece();

        RectTransform rt = _wheelPiecePrefab.transform.GetChild(0).GetComponent<RectTransform>();
        float pieceWidth = Mathf.Lerp(pieceMinSize.x, pieceMaxSize.x, 1f - Mathf.InverseLerp(piecesMin, piecesMax, wheelPieces.Length));
        float pieceHeight = Mathf.Lerp(pieceMinSize.y, pieceMaxSize.y, 1f - Mathf.InverseLerp(piecesMin, piecesMax, wheelPieces.Length));
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pieceWidth);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pieceHeight);

        for (int i = 0; i < wheelPieces.Length; i++)
        {
            DrawPiece(i);
        }

        Destroy(_wheelPiecePrefab);
    }

    private void DrawPiece(int index)
    {
        WheelPiece piece = wheelPieces[index];
        Transform pieceTrns = InstantiatePiece().transform.GetChild(0);

        pieceTrns.GetChild(0).GetComponent<Image>().sprite = piece.Icon;
        pieceTrns.GetChild(1).GetComponent<Text>().text = piece.Label;
        pieceTrns.GetChild(2).GetComponent<Text>().text = piece.Amount.ToString();

        Transform lineTrns = Instantiate(_linePrefab, _linesParent.position, Quaternion.identity, _linesParent).transform;
        lineTrns.RotateAround(_wheelPiecesParent.position, Vector3.back, (pieceAngle * index) + halfPieceAngle);

        pieceTrns.RotateAround(_wheelPiecesParent.position, Vector3.back, pieceAngle * index);
    }

    private GameObject InstantiatePiece()
    {
        return Instantiate(_wheelPiecePrefab, _wheelPiecesParent.position, Quaternion.identity, _wheelPiecesParent);
    }


    public void Spin()
    {
        if (_isSpinning == false)
        {
            _isSpinning = true;

            if (onSpinStartEvent != null)
            {
                onSpinStartEvent.Invoke();
            }

            int index = GetRandomPieceIndex();
            WheelPiece piece = wheelPieces[index];

            if (piece.Chance == 0 && nonZeroChancesIndices.Count != 0)
            {
                index = nonZeroChancesIndices[Random.Range(0, nonZeroChancesIndices.Count)];
                piece = wheelPieces[index];
            }

            float angle = -(pieceAngle * index);

            float rightOffset = (angle - halfPieceAngleWithPaddings) % 360;
            float leftOffset = (angle + halfPieceAngleWithPaddings) % 360;

            float randomAngle = Random.Range(leftOffset, rightOffset);

            Vector3 targetRotation = Vector3.back * (randomAngle + 2 * 360 * spinDuration);

            //float prevAngle = wheelCircle.eulerAngles.z + halfPieceAngle ;
            float prevAngle, currentAngle;
            prevAngle = currentAngle = _wheelCircle.eulerAngles.z;

            bool isIndicatorOnTheLine = false;

            _wheelCircle
            .DORotate(targetRotation, spinDuration, RotateMode.Fast)
            .SetEase(Ease.InOutQuart)
            .OnUpdate(() => 
            {
                float diff = Mathf.Abs(prevAngle - currentAngle);
                if (diff >= halfPieceAngle)
                {
                    if (isIndicatorOnTheLine)
                    {
                        int randomIndex = Random.Range(0, _tickSounds.Count);
                        AudioHandler.Instance.PlaySound(_tickSounds[randomIndex]);
                    }

                    prevAngle = currentAngle;
                    isIndicatorOnTheLine = !isIndicatorOnTheLine;
                }

                currentAngle = _wheelCircle.eulerAngles.z;
            })
            .OnComplete(() => 
            {
                _isSpinning = false;
                if (onSpinEndEvent != null)
                {
                    onSpinEndEvent.Invoke(piece);
                }

                onSpinStartEvent = null;
                onSpinEndEvent = null;
            });
        }
    }

    public void OnSpinStart(UnityAction action)
    {
        onSpinStartEvent = action;
    }

    public void OnSpinEnd(UnityAction<WheelPiece> action)
    {
        onSpinEndEvent = action;
    }

    private int GetRandomPieceIndex()
    {
        double r = rand.NextDouble() * accumulatedWeight;

        for (int i = 0; i < wheelPieces.Length; i++)
        {
            if (wheelPieces[i]._weight >= r)
            {
                return i;
            }
        }

        return 0;
    }

    private void CalculateWeightsAndIndices()
    {
        for (int i = 0; i < wheelPieces.Length; i++)
        {
            WheelPiece piece = wheelPieces[i];

            accumulatedWeight += piece.Chance;
            piece._weight = accumulatedWeight;

            piece.Index = i;

            if (piece.Chance > 0)
            {
                nonZeroChancesIndices.Add(i);
            }
        }
    }

    private void OnValidate()
    {
        if (_pickerWheelTransform != null)
        {
            _pickerWheelTransform.localScale = new Vector3(wheelSize, wheelSize, 1f);
        }

        if (wheelPieces.Length > piecesMax || wheelPieces.Length < piecesMin)
        {
            Debug.LogError("[ PickerWheelwheel ]  pieces length must be between " + piecesMin + " and " + piecesMax);
        }
    }
}