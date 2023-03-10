//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.ServedGuestComponent playECSServedGuest { get { return (Play.ECS.ServedGuestComponent)GetComponent(GameComponentsLookup.PlayECSServedGuest); } }
    public bool hasPlayECSServedGuest { get { return HasComponent(GameComponentsLookup.PlayECSServedGuest); } }

    public void AddPlayECSServedGuest(GameEntity newGuestEntity) {
        var index = GameComponentsLookup.PlayECSServedGuest;
        var component = (Play.ECS.ServedGuestComponent)CreateComponent(index, typeof(Play.ECS.ServedGuestComponent));
        component.GuestEntity = newGuestEntity;
        AddComponent(index, component);
    }

    public void ReplacePlayECSServedGuest(GameEntity newGuestEntity) {
        var index = GameComponentsLookup.PlayECSServedGuest;
        var component = (Play.ECS.ServedGuestComponent)CreateComponent(index, typeof(Play.ECS.ServedGuestComponent));
        component.GuestEntity = newGuestEntity;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSServedGuest() {
        RemoveComponent(GameComponentsLookup.PlayECSServedGuest);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayECSServedGuest;

    public static Entitas.IMatcher<GameEntity> PlayECSServedGuest {
        get {
            if (_matcherPlayECSServedGuest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSServedGuest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSServedGuest = matcher;
            }

            return _matcherPlayECSServedGuest;
        }
    }
}
