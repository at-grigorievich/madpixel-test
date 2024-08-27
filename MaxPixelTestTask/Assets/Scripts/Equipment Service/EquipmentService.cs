using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ATG.Equipment
{
    public class EquipmentService : IEquipmentService
    {
        private readonly Transform _transform;
        private readonly MeshFilter _meshFilter;
        private readonly MeshRenderer _renderer;

        public EquipmentData CurrentEquipment { get; private set; }

        public bool IsActive { get; private set; }

        public EquipmentService(GameObject equipmentTarget)
        {
            if(equipmentTarget.TryGetComponent<MeshFilter>(out _meshFilter) == false)
                throw new ArgumentException("equipment target must have MeshFilter & MeshRenderer");

            _renderer = equipmentTarget.GetComponent<MeshRenderer>();
            _transform = equipmentTarget.transform;
        }

        public void SetActive(bool isActive)
        {
            _renderer.enabled = isActive;

            IsActive = isActive;
        }

        public void Equip(EquipmentData equipmentConfig)
        {
            if (IsActive == false || equipmentConfig == null) return;
            if (ReferenceEquals(equipmentConfig, CurrentEquipment) == true) return;

            CurrentEquipment = equipmentConfig;

            UpdateMesh();
            UpdateLocalTransform();
        }

        public void ClearAll()
        {
            if (IsActive == false) return;

            CurrentEquipment = null;

            UpdateMesh();
            UpdateLocalTransform();
        }

        private void UpdateMesh()
        {
            if (CurrentEquipment == null)
            {
                _meshFilter.sharedMesh = null;
                _renderer.sharedMaterials = null;
            }
            else
            {
                _meshFilter.sharedMesh = CurrentEquipment.Mesh;
                _renderer.sharedMaterials = CurrentEquipment.Materials;
            }
        }

        private void UpdateLocalTransform()
        {
            if (CurrentEquipment == null)
            {
                _transform.localPosition = Vector3.zero;
                _transform.localRotation = Quaternion.identity;
                _transform.localScale = Vector3.one;
            }
            else
            {
                _transform.localPosition = CurrentEquipment.LocalPosition;
                _transform.localRotation = Quaternion.Euler(CurrentEquipment.LocalEulerAngles);
                _transform.localScale = CurrentEquipment.LocalScale;
            }
        }
    }
}