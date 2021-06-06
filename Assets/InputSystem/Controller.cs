// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""_mouse"",
            ""id"": ""3b5fdd51-50db-490b-baec-7664657985e5"",
            ""actions"": [
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""a2d462fe-ed92-405d-9c33-7801f83c9148"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""8173d594-48b8-4211-901b-a853b8922e4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d57a7e1a-c9af-4d17-b292-29d1c889fbc3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcdb7f38-fca5-4bf3-8bb7-6f3913cd3cee"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""660b1255-1915-4e15-8e8b-fd2bfaebe834"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f30703ae-975b-40bf-ab6f-8bbfb9c4b10b"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // _mouse
        m__mouse = asset.FindActionMap("_mouse", throwIfNotFound: true);
        m__mouse_Delta = m__mouse.FindAction("Delta", throwIfNotFound: true);
        m__mouse_Touch = m__mouse.FindAction("Touch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // _mouse
    private readonly InputActionMap m__mouse;
    private I_mouseActions m__mouseActionsCallbackInterface;
    private readonly InputAction m__mouse_Delta;
    private readonly InputAction m__mouse_Touch;
    public struct _mouseActions
    {
        private @Controller m_Wrapper;
        public _mouseActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Delta => m_Wrapper.m__mouse_Delta;
        public InputAction @Touch => m_Wrapper.m__mouse_Touch;
        public InputActionMap Get() { return m_Wrapper.m__mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_mouseActions set) { return set.Get(); }
        public void SetCallbacks(I_mouseActions instance)
        {
            if (m_Wrapper.m__mouseActionsCallbackInterface != null)
            {
                @Delta.started -= m_Wrapper.m__mouseActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m__mouseActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m__mouseActionsCallbackInterface.OnDelta;
                @Touch.started -= m_Wrapper.m__mouseActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m__mouseActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m__mouseActionsCallbackInterface.OnTouch;
            }
            m_Wrapper.m__mouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
            }
        }
    }
    public _mouseActions @_mouse => new _mouseActions(this);
    public interface I_mouseActions
    {
        void OnDelta(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
}
