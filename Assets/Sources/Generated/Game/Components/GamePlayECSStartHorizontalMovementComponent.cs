//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.StartHorizontalMovementComponent playECSStartHorizontalMovement { get { return (Play.ECS.StartHorizontalMovementComponent)GetComponent(GameComponentsLookup.PlayECSStartHorizontalMovement); } }
    public bool hasPlayECSStartHorizontalMovement { get { return HasComponent(GameComponentsLookup.PlayECSStartHorizontalMovement); } }

    public void AddPlayECSStartHorizontalMovement(float newTargetX, System.Action newCallback) {
        var index = GameComponentsLookup.PlayECSStartHorizontalMovement;
        var component = (Play.ECS.StartHorizontalMovementComponent)CreateComponent(index, typeof(Play.ECS.StartHorizontalMovementComponent));
        component.TargetX = newTargetX;
        component.Callback = newCallback;
        AddComponent(index, component);
    }

    public void ReplacePlayECSStartHorizontalMovement(float newTargetX, System.Action newCallback) {
        var index = GameComponentsLookup.PlayECSStartHorizontalMovement;
        var component = (Play.ECS.StartHorizontalMovementComponent)CreateComponent(index, typeof(Play.ECS.StartHorizontalMovementComponent));
        component.TargetX = newTargetX;
        component.Callback = newCallback;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSStartHorizontalMovement() {
        RemoveComponent(GameComponentsLookup.PlayECSStartHorizontalMovement);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayECSStartHorizontalMovement;

    public static Entitas.IMatcher<GameEntity> PlayECSStartHorizontalMovement {
        get {
            if (_matcherPlayECSStartHorizontalMovement == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSStartHorizontalMovement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSStartHorizontalMovement = matcher;
            }

            return _matcherPlayECSStartHorizontalMovement;
        }
    }
}
