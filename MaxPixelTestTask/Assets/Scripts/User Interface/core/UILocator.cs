using System;
using System.Collections.Generic;
using ATG.UserInterface;

namespace ATG.MVC
{

    public sealed class UILocator
    {
        private readonly IReadOnlyDictionary<UIElementType, UIElement> _views;

        public UILocator(IEnumerable<KeyValuePair<UIElementType, UIElement>> views)
        {
            _views = new Dictionary<UIElementType, UIElement>(views);
        }

        public void ShowByType(UIElementType type)
        {
            if(_views.ContainsKey(type) == false)
             throw new NullReferenceException($"UI Element with {type} type not exist");

            _views[type].Show();
        }

        public void HideByType(UIElementType type)
        {
            if(_views.ContainsKey(type) == false)
                throw new NullReferenceException($"UI Element with {type} type not exist");

            _views[type].Hide();
        }
    }
}