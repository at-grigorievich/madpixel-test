using System;
using ATG.Equipment;
using ATG.Mana;
using ATG.Messages;
using ATG.Observable;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace ATG.UserInterface
{
    public sealed class UseEquipmentView : UIElement
    {
        [SerializeField] private Text equipmentName;
        [SerializeField] private ScaleButton equipButton;
        [SerializeField] private ScaleButton dropButton;
        [SerializeField] private Text getManaBySellValue;

        [Inject] private IMessageBroker _messageBroker;

        [Inject] private IManaService _manaService;
        [Inject] private VisualEquipmentService _visualEquipmentService;
        [Inject] private IEquipmentService _equipmentService;
        [Inject] private EquipmentDataSet _equipmentSet;

        private EquipmentData _selectedEquipment;

        public override UIElementType Type => UIElementType.EquipmentDrop;

        public override void Show()
        {
            _selectedEquipment = _equipmentSet.GetRndData();

            _visualEquipmentService.SetActive(true);
            _visualEquipmentService.ShowEquipment(_selectedEquipment);

            equipmentName.text = _selectedEquipment.Name;
            getManaBySellValue.text = $"+{_selectedEquipment.SellManaCost}";

            equipButton.OnClick += OnEquipClick;
            dropButton.OnClick += OnDropClick;

            base.Show();
        }

        public override void Hide()
        {
            base.Hide();

            equipButton.OnClick -= OnEquipClick;
            dropButton.OnClick -= OnDropClick;

            _visualEquipmentService.SetActive(false);

            _selectedEquipment = null;
        }

        private void OnEquipClick()
        {
            if (_selectedEquipment == null)
                throw new NullReferenceException("selected equipment is null!!");

            _equipmentService.Equip(_selectedEquipment);

            _messageBroker.Send(new CompleteDiggingMessage());
            Hide();
        }

        private void OnDropClick()
        {
            if (_selectedEquipment == null)
                throw new NullReferenceException("selected equipment is null!!");

            _manaService.AddMana(_selectedEquipment.SellManaCost);
            _messageBroker.Send(new CompleteDiggingMessage());
            Hide();
        }
    }
}