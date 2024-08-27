using System;
using System.Collections.Generic;
using System.Linq;
using ATG.Factory;
using ATG.MVC;
using UnityEngine;
using VContainer;

namespace ATG.UserInterface
{
    [Serializable]
    public sealed class UILocatorCreator : InjectFactory
    {
        [SerializeField] private UIElement[] uiElements;

        public override void CreateAndInject(IContainerBuilder builder)
        {
            IEnumerable<KeyValuePair<UIElementType, UIElement>> elements = 
                uiElements.Select(ui => new KeyValuePair<UIElementType, UIElement>(ui.Type, ui));
            
            builder.Register<UILocator>(Lifetime.Singleton)
                .WithParameter(elements);
        }
    }
}