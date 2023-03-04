using System.Collections;
using Core.Game.Play.ECS;
using Core.Game.UI.Common;
using Entitas;
using Play.ECS.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public enum IngredientProducerState
    {
        Empty,
        Prepare,
        Done
    }

    public class IngredientProducerViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private IngredientType _ingredientType;

        [SerializeField]
        private float _prepareTime;

        [SerializeField]
        private Button _produceButton;

        [SerializeField]
        private Button _collectButton;

        [SerializeField]
        private Image _timerFill;

        [SerializeField]
        private StateViewContainer _stateViewContainer;

        private Coroutine _prepareCoroutine;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSIngredientProducerView(this);
            Entity.OnComponentRemoved += OnCollectedIngredientRemoved;
        }

        private void OnCollectedIngredientRemoved(IEntity entity, int index, IComponent component)
        {
            if (component is CollectedIngredientComponent)
            {
                ResetView();
            }
        }

        private void Awake()
        {
            ResetView();

            _produceButton.onClick.AddListener(OnPrepare);
            _collectButton.onClick.AddListener(OnCollect);
        }

        private void OnPrepare()
        {
            _prepareCoroutine = StartCoroutine(Prepare());

            _produceButton.gameObject.SetActive(false);
        }

        private void OnCollect()
        {
            Entity.AddPlayECSIngredient(_ingredientType);
        }


        // to UniTask
        private IEnumerator Prepare()
        {
            if (_prepareTime > 0)
            {
                yield return StartCoroutine(TimerCoroutine(_prepareTime));
            }

            CompleteIngredient();
        }

        private IEnumerator TimerCoroutine(float prepareTime)
        {
            _stateViewContainer.State = IngredientProducerState.Prepare.ToString();

            while (prepareTime > 0)
            {
                _timerFill.fillAmount = (_prepareTime - prepareTime) / _prepareTime;

                prepareTime -= Time.deltaTime;
                yield return null;
            }

            _timerFill.fillAmount = 1;
        }

        private void CompleteIngredient()
        {
            _stateViewContainer.State = IngredientProducerState.Done.ToString();

            _collectButton.gameObject.SetActive(true);
            _produceButton.gameObject.SetActive(false);
        }

        private void ResetView()
        {
            if (_prepareTime == 0)
            {
                _stateViewContainer.State = IngredientProducerState.Done.ToString();
                _collectButton.gameObject.SetActive(true);
                _produceButton.gameObject.SetActive(false);
            }
            else
            {
                _stateViewContainer.State = IngredientProducerState.Empty.ToString();

                _timerFill.fillAmount = 0;

                _collectButton.gameObject.SetActive(false);
                _produceButton.gameObject.SetActive(true);
            }
        }

        protected override void OnDestroyEntity(IEntity entity)
        {
            Entity.OnComponentRemoved -= OnCollectedIngredientRemoved;
        }
    }
}