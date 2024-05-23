//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/CheatsInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CheatsInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CheatsInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CheatsInput"",
    ""maps"": [
        {
            ""name"": ""Cheats"",
            ""id"": ""d1230032-826e-42c6-99fd-f0b5932b6470"",
            ""actions"": [
                {
                    ""name"": ""MaxAmmo"",
                    ""type"": ""Button"",
                    ""id"": ""c0aa76fc-4981-4ca3-a9ca-8cd2554643ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextLevel"",
                    ""type"": ""Button"",
                    ""id"": ""98128e37-8413-40c4-9911-2dc3a63d778f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db47c945-326d-414f-9218-9c31b6d154c6"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MaxAmmo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""880567b5-55e9-4681-bc68-a9f66f87c739"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cheats
        m_Cheats = asset.FindActionMap("Cheats", throwIfNotFound: true);
        m_Cheats_MaxAmmo = m_Cheats.FindAction("MaxAmmo", throwIfNotFound: true);
        m_Cheats_NextLevel = m_Cheats.FindAction("NextLevel", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Cheats
    private readonly InputActionMap m_Cheats;
    private List<ICheatsActions> m_CheatsActionsCallbackInterfaces = new List<ICheatsActions>();
    private readonly InputAction m_Cheats_MaxAmmo;
    private readonly InputAction m_Cheats_NextLevel;
    public struct CheatsActions
    {
        private @CheatsInput m_Wrapper;
        public CheatsActions(@CheatsInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MaxAmmo => m_Wrapper.m_Cheats_MaxAmmo;
        public InputAction @NextLevel => m_Wrapper.m_Cheats_NextLevel;
        public InputActionMap Get() { return m_Wrapper.m_Cheats; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatsActions set) { return set.Get(); }
        public void AddCallbacks(ICheatsActions instance)
        {
            if (instance == null || m_Wrapper.m_CheatsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CheatsActionsCallbackInterfaces.Add(instance);
            @MaxAmmo.started += instance.OnMaxAmmo;
            @MaxAmmo.performed += instance.OnMaxAmmo;
            @MaxAmmo.canceled += instance.OnMaxAmmo;
            @NextLevel.started += instance.OnNextLevel;
            @NextLevel.performed += instance.OnNextLevel;
            @NextLevel.canceled += instance.OnNextLevel;
        }

        private void UnregisterCallbacks(ICheatsActions instance)
        {
            @MaxAmmo.started -= instance.OnMaxAmmo;
            @MaxAmmo.performed -= instance.OnMaxAmmo;
            @MaxAmmo.canceled -= instance.OnMaxAmmo;
            @NextLevel.started -= instance.OnNextLevel;
            @NextLevel.performed -= instance.OnNextLevel;
            @NextLevel.canceled -= instance.OnNextLevel;
        }

        public void RemoveCallbacks(ICheatsActions instance)
        {
            if (m_Wrapper.m_CheatsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICheatsActions instance)
        {
            foreach (var item in m_Wrapper.m_CheatsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CheatsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CheatsActions @Cheats => new CheatsActions(this);
    public interface ICheatsActions
    {
        void OnMaxAmmo(InputAction.CallbackContext context);
        void OnNextLevel(InputAction.CallbackContext context);
    }
}