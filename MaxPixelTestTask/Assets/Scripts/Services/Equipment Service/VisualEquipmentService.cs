using System;
using ATG.Activator;
using UnityEngine;

namespace ATG.Equipment
{
    public class VisualEquipmentService : IActivateable, IDisposable
    {
        private readonly Camera _camera;

        private readonly MeshFilter _meshFilter;
        private readonly MeshRenderer _renderer;

        private readonly Transform _transform;

        public bool IsActive { get; private set; }

        private EquipmentData _currentEquipment;

        public VisualEquipmentService(Camera camera, MeshFilter meshFilter, MeshRenderer renderer)
        {
            _camera = camera;
            _meshFilter = meshFilter;
            _renderer = renderer;

            _transform = _meshFilter.transform;
        }

        public void SetActive(bool isActive)
        {
            if(_camera != null)
            {
                _camera.enabled = isActive;
            }

            if (_renderer != null)
            {
                _renderer.enabled = isActive;
            }

            IsActive = isActive;
        }

        public void ShowEquipment(EquipmentData equipmentConfig)
        {
            if (IsActive == false) return;
            if (ReferenceEquals(_currentEquipment, equipmentConfig) == true) return;

            _meshFilter.sharedMesh = equipmentConfig.Mesh;
            _renderer.sharedMaterials = equipmentConfig.Materials;

            _currentEquipment = equipmentConfig;

            _camera.fieldOfView = equipmentConfig.ZoomValue;
            _transform.localPosition = equipmentConfig.RectPosition;
        }

        public void Dispose()
        {
            if (IsActive == false)
            {
                if(_meshFilter != null)
                {
                    _meshFilter.sharedMesh = null;
                }

                if(_renderer != null)
                {
                    _renderer.sharedMaterials = Array.Empty<Material>();
                }
                _currentEquipment = null;
            }
        }
    }
}