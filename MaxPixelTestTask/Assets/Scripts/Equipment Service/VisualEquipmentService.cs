using System;
using ATG.Activator;
using UnityEngine;

namespace ATG.Equipment
{
    public class VisualEquipmentService: IActivateable
    {
        private readonly Camera _camera;
        
        private readonly MeshFilter _meshFilter;
        private readonly MeshRenderer _renderer;

        public bool IsActive { get; private set;}

        private EquipmentData _currentEquipment;

        public VisualEquipmentService(Camera camera, MeshFilter meshFilter, MeshRenderer renderer)
        {
            _camera = camera;
            _meshFilter = meshFilter;
            _renderer = renderer;
        }

        public void SetActive(bool isActive)
        {
            _renderer.enabled = isActive;

            if(IsActive == false)
            {
                _meshFilter.sharedMesh = null;
                _renderer.sharedMaterials = Array.Empty<Material>();

                _currentEquipment = null;
            }
            
            IsActive = isActive;
        }

        public void ShowEquipment(EquipmentData equipmentConfig)
        {
            if(IsActive == false) return;
            if(ReferenceEquals(_currentEquipment, equipmentConfig) == true) return;

            _meshFilter.sharedMesh = equipmentConfig.Mesh;
            _renderer.sharedMaterials = equipmentConfig.Materials;

            _currentEquipment = equipmentConfig;
        }
    }
}