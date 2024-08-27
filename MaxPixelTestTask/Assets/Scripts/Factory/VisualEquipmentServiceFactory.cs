using System;
using ATG.Equipment;
using UnityEngine;
using VContainer;

namespace ATG.Factory
{
    [Serializable]
    public sealed class VisualEquipmentServiceFactory: InjectFactory
    {
        [SerializeField] private Camera rendererCamera;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshRenderer renderer;

        public override void CreateAndInject(IContainerBuilder builder)
        {
            builder.Register<VisualEquipmentService>(Lifetime.Singleton)
                .WithParameter<Camera>(rendererCamera)
                .WithParameter<MeshFilter>(meshFilter)
                .WithParameter<MeshRenderer>(renderer);
        }
    }
}