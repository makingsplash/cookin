//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.SpawnIngredientViewsComponent playECSSpawnIngredientViews { get { return (Play.ECS.SpawnIngredientViewsComponent)GetComponent(GameComponentsLookup.PlayECSSpawnIngredientViews); } }
    public bool hasPlayECSSpawnIngredientViews { get { return HasComponent(GameComponentsLookup.PlayECSSpawnIngredientViews); } }

    public void AddPlayECSSpawnIngredientViews(System.Collections.Generic.List<Core.Game.Play.ECS.IngredientType> newIngredients, UnityEngine.Transform newRoot) {
        var index = GameComponentsLookup.PlayECSSpawnIngredientViews;
        var component = (Play.ECS.SpawnIngredientViewsComponent)CreateComponent(index, typeof(Play.ECS.SpawnIngredientViewsComponent));
        component.Ingredients = newIngredients;
        component.Root = newRoot;
        AddComponent(index, component);
    }

    public void ReplacePlayECSSpawnIngredientViews(System.Collections.Generic.List<Core.Game.Play.ECS.IngredientType> newIngredients, UnityEngine.Transform newRoot) {
        var index = GameComponentsLookup.PlayECSSpawnIngredientViews;
        var component = (Play.ECS.SpawnIngredientViewsComponent)CreateComponent(index, typeof(Play.ECS.SpawnIngredientViewsComponent));
        component.Ingredients = newIngredients;
        component.Root = newRoot;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSSpawnIngredientViews() {
        RemoveComponent(GameComponentsLookup.PlayECSSpawnIngredientViews);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayECSSpawnIngredientViews;

    public static Entitas.IMatcher<GameEntity> PlayECSSpawnIngredientViews {
        get {
            if (_matcherPlayECSSpawnIngredientViews == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSSpawnIngredientViews);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSSpawnIngredientViews = matcher;
            }

            return _matcherPlayECSSpawnIngredientViews;
        }
    }
}
