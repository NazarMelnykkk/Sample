using System;
using UnityEngine;

namespace WheleOfFortune
{
    public class BetController : MonoBehaviour
    {
        [SerializeField] private WheelOfFortuneController _wheelOfFortuneController;
        [SerializeField] private InputFieldBetController _inputFieldBetController;
        [SerializeField] private int CurrentBet;

        public Action<int> OnChangeValueBetEvent;


        private void Start()
        {
            ChangeBet(CurrentBet);
        }


        private void OnEnable()
        {
            _wheelOfFortuneController.OnSpinStartEvent += BetCalculation;
            _wheelOfFortuneController.OnSpinEndEvent += CheckBet;
        }

        protected void OnDisable()
        {
            _wheelOfFortuneController.OnSpinStartEvent -= BetCalculation;
            _wheelOfFortuneController.OnSpinEndEvent -= CheckBet;
        }

        public int CheckBet(int value)
        {
            ChangeBet(value);
            return CurrentBet;
        }

        public void CheckBet()
        {
            ChangeBet(CurrentBet);
        }

        protected void ChangeBet(int value)
        {
            CurrentBet = CoinHandler.Instance.ChechAmount(value);
            if (CurrentBet < 0) 
            {
                CurrentBet = 0;
            }
            OnChangeValueBetEvent?.Invoke(CurrentBet);
        }

        protected void BetCalculation()
        {
            CoinHandler.Instance.RemoveCoins(CurrentBet);
        }

        public void WinningCalculation(int multiplication)
        {
            int valueSum = CurrentBet * multiplication;

            CoinHandler.Instance.AddCoins(valueSum);
        }

    }
}

