//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.IngredientComponent playECSIngredient { get { return (Play.ECS.IngredientComponent)GetComponent(GameComponentsLookup.PlayECSIngredient); } }
    public bool hasPlayECSIngredient { get { return HasComponent(GameComponentsLookup.PlayECSIngredient); } }

    public void AddPlayECSIngredient(Core.Game.Play.ECS.IngredientType newIngredientType) {
        var index = GameComponentsLookup.PlayECSIngredient;
        var component = (Play.ECS.IngredientComponent)CreateComponent(index, typeof(Play.ECS.IngredientComponent));
        component.IngredientType = newIngredientType;
        AddComponent(index, component);
    }

    public void ReplacePlayECSIngredient(Core.Game.Play.ECS.IngredientType newIngredientType) {
        var index = GameComponentsLookup.PlayECSIngredient;
        var component = (Play.ECS.IngredientComponent)CreateComponent(index, typeof(Play.ECS.IngredientComponent));
        component.IngredientType = newIngredientType;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSIngredient() {
        RemoveComponent(GameComponentsLookup.PlayECSIngredient);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayECSIngredient;

    public static Entitas.IMatcher<GameEntity> PlayECSIngredient {
        get {
            if (_matcherPlayECSIngredient == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSIngredient);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSIngredient = matcher;
            }

            return _matcherPlayECSIngredient;
        }
    }
}
