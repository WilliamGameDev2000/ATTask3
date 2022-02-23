// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""walkmap"",
            ""id"": ""50ee14f2-89c7-4fe0-8c48-7c6d7f343cc6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""ba9f5f26-d5f9-4585-9d99-ff593446808c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""17a7f7e6-153a-4394-bf2b-96a59b39d242"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keys"",
                    ""id"": ""7c4cf707-2d36-4cda-8112-62e8df175627"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2985c344-b5c3-4e6b-bcd2-5608c7568139"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5bba4847-be9f-431c-bb3d-f21d68ac6456"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cef427c6-6673-41bd-9033-a87991a78e47"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b1a6c776-008b-4918-9705-bbcd5754dff7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""065bdb49-3920-4c91-be69-ef7efa32b36c"",
                    ""path"": ""<Gamepad>/leftstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""949ac751-00a5-4284-bbed-764f2c3f9279"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // walkmap
        m_walkmap = asset.FindActionMap("walkmap", throwIfNotFound: true);
        m_walkmap_Movement = m_walkmap.FindAction("Movement", throwIfNotFound: true);
        m_walkmap_MouseLook = m_walkmap.FindAction("MouseLook", throwIfNotFound: true);
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

    // walkmap
    private readonly InputActionMap m_walkmap;
    private IWalkmapActions m_WalkmapActionsCallbackInterface;
    private readonly InputAction m_walkmap_Movement;
    private readonly InputAction m_walkmap_MouseLook;
    public struct WalkmapActions
    {
        private @Player m_Wrapper;
        public WalkmapActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_walkmap_Movement;
        public InputAction @MouseLook => m_Wrapper.m_walkmap_MouseLook;
        public InputActionMap Get() { return m_Wrapper.m_walkmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkmapActions set) { return set.Get(); }
        public void SetCallbacks(IWalkmapActions instance)
        {
            if (m_Wrapper.m_WalkmapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMovement;
                @MouseLook.started -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_WalkmapActionsCallbackInterface.OnMouseLook;
            }
            m_Wrapper.m_WalkmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
            }
        }
    }
    public WalkmapActions @walkmap => new WalkmapActions(this);
    public interface IWalkmapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
    }
}
