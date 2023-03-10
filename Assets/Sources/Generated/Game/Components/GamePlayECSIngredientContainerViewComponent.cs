//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.IngredientContainerViewComponent playECSIngredientContainerView { get { return (Play.ECS.IngredientContainerViewComponent)GetComponent(GameComponentsLookup.PlayECSIngredientContainerView); } }
    public bool hasPlayECSIngredientContainerView { get { return HasComponent(GameComponentsLookup.PlayECSIngredientContainerView); } }

    public void AddPlayECSIngredientContainerView(Play.ECS.IngredientsContainerViewBehaviour newView, System.Collections.Generic.List<Core.Game.Play.ECS.IngredientType> newIngredients) {
        var index = GameComponentsLookup.PlayECSIngredientContainerView;
        var component = (Play.ECS.IngredientContainerViewComponent)CreateComponent(index, typeof(Play.ECS.IngredientContainerViewComponent));
        component.View = newView;
        component.Ingredients = newIngredients;
        AddComponent(index, component);
    }

    public void ReplacePlayECSIngredientContainerView(Play.ECS.IngredientsContainerViewBehaviour newView, System.Collections.Generic.List<Core.Game.Play.ECS.IngredientType> newIngredients) {
        var index = GameComponentsLookup.PlayECSIngredientContainerView;
        var component = (Play.ECS.IngredientContainerViewComponent)CreateComponent(index, typeof(Play.ECS.IngredientContainerViewComponent));
        component.View = newView;
        component.Ingredients = newIngredients;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSIngredientContainerView() {
        RemoveComponent(GameComponentsLookup.PlayECSIngredientContainerView);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayECSIngredientContainerView;

    public static Entitas.IMatcher<GameEntity> PlayECSIngredientContainerView {
        get {
            if (_matcherPlayECSIngredientContainerView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSIngredientContainerView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSIngredientContainerView = matcher;
            }

            return _matcherPlayECSIngredientContainerView;
        }
    }
}
