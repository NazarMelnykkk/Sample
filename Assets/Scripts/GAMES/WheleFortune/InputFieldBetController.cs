using UnityEngine;

namespace WheleOfFortune
{
    public class InputFieldBetController : InputFieldBase
    {
        [SerializeField] private BetController _betController;

/*        private void Start()
        {
            _inputField.text = $"{_betController.CurrentBet}";
        }*/

        protected override void OnEnable()
        {
            base.OnEnable();

            _betController.OnChangeValueBetEvent += ValueChange;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _betController.OnChangeValueBetEvent -= ValueChange;
        }

        public override void ValueChange(string value)
        {
            base.ValueChange(value);

            if (int.TryParse(value, out int intValue))
            {
                _inputField.text = $"{_betController.CheckBet(intValue)}";
            }
        }

        private void ValueChange(int Value)
        {
            if (Value < 0)
            {
                Value = 0;
            }
            _inputField.text = Value.ToString();
        }
    }
}

