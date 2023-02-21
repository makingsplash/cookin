//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Play.ECS.UnservedGuestComponent playECSUnservedGuest { get { return (Play.ECS.UnservedGuestComponent)GetComponent(GameComponentsLookup.PlayECSUnservedGuest); } }
    public bool hasPlayECSUnservedGuest { get { return HasComponent(GameComponentsLookup.PlayECSUnservedGuest); } }

    public void AddPlayECSUnservedGuest(GameEntity newGuestEntity) {
        var index = GameComponentsLookup.PlayECSUnservedGuest;
        var component = (Play.ECS.UnservedGuestComponent)CreateComponent(index, typeof(Play.ECS.UnservedGuestComponent));
        component.GuestEntity = newGuestEntity;
        AddComponent(index, component);
    }

    public void ReplacePlayECSUnservedGuest(GameEntity newGuestEntity) {
        var index = GameComponentsLookup.PlayECSUnservedGuest;
        var component = (Play.ECS.UnservedGuestComponent)CreateComponent(index, typeof(Play.ECS.UnservedGuestComponent));
        component.GuestEntity = newGuestEntity;
        ReplaceComponent(index, component);
    }

    public void RemovePlayECSUnservedGuest() {
        RemoveComponent(GameComponentsLookup.PlayECSUnservedGuest);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayECSUnservedGuest;

    public static Entitas.IMatcher<GameEntity> PlayECSUnservedGuest {
        get {
            if (_matcherPlayECSUnservedGuest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayECSUnservedGuest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayECSUnservedGuest = matcher;
            }

            return _matcherPlayECSUnservedGuest;
        }
    }
}
