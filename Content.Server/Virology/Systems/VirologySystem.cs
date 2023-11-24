using Content.Shared.Virology;
using Robust.Shared.Player;
using Robust.Shared.GameObjects;
using System.Linq;
using Content.Shared.Coordinates;
using Content.Shared.Whitelist;
using Robust.Shared.Placement;
using Robust.Shared.GameObjects.Components;
using Robust.Shared.Physics;
using Robust.Shared.Maths;
using Content.Shared.Mobs.Components;

namespace Content.Server.Virology.Systems;

public sealed class VirologySystem : SharedVirologySystem
{
    private readonly IEntityManager _entityManager;
    public VirologySystem(IEntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var infectionRadius = 10.0f; //TODO: Replace with actualy infection radius calculation

        var entitiesWithDisease = _entityManager.GetEntities()
            .Where(entity => _entityManager.HasComponent<DiseaseComponent>(entity));
        foreach (var entity in entitiesWithDisease)
        {
            if(_entityManager.TryGetComponent(entity, out TransformComponent? infectedTransofrm))
            {
                var infectedPosition = infectedTransofrm.WorldPosition;
                var allEntities = _entityManager.GetEntities()
                    .Where(entity => _entityManager.HasComponent<MobStateComponent>(entity));

                foreach(var otherEntity in allEntities)
                {
                    if(_entityManager.TryGetComponent(otherEntity, out MobStateComponent? mobStateComponent) && !_entityManager.HasComponent<DiseaseComponent>(otherEntity) && _entityManager.TryGetComponent(otherEntity, out TransformComponent? otherTransofrm))
                    {
                        if(mobStateComponent.CurrentState != Shared.Mobs.MobState.Dead)
                        {
                            var otherPosition = otherTransofrm.WorldPosition;
                            var distance = (infectedPosition - otherPosition).Length;

                            if(distance() < infectionRadius)
                            {
                                var diseaseComponent = new DiseaseComponent();
                                _entityManager.AddComponent(otherEntity, diseaseComponent);
                            }
                        }
                    }
                }
            }

        }
    }
}
