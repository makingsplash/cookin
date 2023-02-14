using System.Collections;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientProducerViewBehaviour : EntityViewBehaviour
    {
        private static readonly Color STATE_EMPTY = Color.gray;
        private static readonly Color STATE_IN_PROCESS = Color.yellow;
        private static readonly Color STATE_READY = Color.green;

        [SerializeField]
        private IngredientType _ingredientType;

        [SerializeField]
        private float _prepareTime;

        [SerializeField]
        private Image _ingredientImage;

        [SerializeField]
        private Button _produceButton;

        [SerializeField]
        private Button _collectButton;

        [SerializeField]
        private TextMeshProUGUI _textPrepareTimer;

        [SerializeField]
        private TextMeshProUGUI _ingredientName;

        private Coroutine _prepareCoroutine;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSIngredientProducerView(this);
        }

        private void Awake()
        {
            _ingredientName.text = _ingredientType.ToString();
            _collectButton.interactable = false;
            _ingredientImage.color = STATE_EMPTY;

            _produceButton.onClick.AddListener(OnPrepare);
            _collectButton.onClick.AddListener(OnCollect);
        }

        private void OnPrepare()
        {
            _prepareCoroutine = StartCoroutine(Prepare());

            _collectButton.interactable = false;
            _produceButton.interactable = false;
        }

        private void OnCollect()
        {
            Entity.AddPlayECSIngredient(_ingredientType);
        }

        private IEnumerator Prepare()
        {
            float prepareTime = _prepareTime;

            if (prepareTime > 0)
            {
                _ingredientImage.color = STATE_IN_PROCESS;
            }

            while (prepareTime > 0)
            {
                _textPrepareTimer.text = $"{prepareTime:F}";

                prepareTime -= Time.deltaTime;
                yield return null;
            }

            CompleteIngredient();
        }

        private void CompleteIngredient()
        {
            _ingredientImage.color = STATE_READY;

            _collectButton.interactable = true;
            _produceButton.interactable = false;
        }

        public void ResetView()
        {
            _ingredientImage.color = STATE_EMPTY;

            _collectButton.interactable = false;
            _produceButton.interactable = true;
        }
    }
}