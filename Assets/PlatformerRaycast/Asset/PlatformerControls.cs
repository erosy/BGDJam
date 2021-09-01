// GENERATED AUTOMATICALLY FROM 'Assets/PlatformerRaycast/Asset/PlatformerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlatformerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlatformerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlatformerControls"",
    ""maps"": [
        {
            ""name"": ""MainGameplay"",
            ""id"": ""5df8fe5c-aee7-4aa6-8b7d-f98f56f331ca"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d79ddf6-a5c3-4039-b66e-b61b5d735e90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2da9928a-f52e-4b3b-8aac-e9abeddd9d06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""548399b2-629f-4c49-a2da-18e7fbfebf59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""c469cca0-b628-4b2f-9630-00d8814abbd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""fd877d3d-df4d-4fb3-9646-50f26b6a20f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8a64ea81-4039-4af7-8874-30b947a6aa24"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""56ea5f4b-301b-4cb5-b4ff-60123ac71626"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e9564440-fda3-4940-8609-1331161b08c1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c13bec8-d92b-4639-aa3a-5e20f93329d8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fff47c66-6965-4272-80d9-4e1c73c655be"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f29b13c1-7c40-4fe7-931f-1ed754827b9f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84b68ab9-23c1-4c86-b395-2b24edf62715"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbdefbdf-3e17-484e-ac22-c6baaf6654e9"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a35c4bb2-3bb8-4f58-bbd0-a02b58853716"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainGameplay
        m_MainGameplay = asset.FindActionMap("MainGameplay", throwIfNotFound: true);
        m_MainGameplay_Move = m_MainGameplay.FindAction("Move", throwIfNotFound: true);
        m_MainGameplay_Jump = m_MainGameplay.FindAction("Jump", throwIfNotFound: true);
        m_MainGameplay_Teleport = m_MainGameplay.FindAction("Teleport", throwIfNotFound: true);
        m_MainGameplay_Interaction = m_MainGameplay.FindAction("Interaction", throwIfNotFound: true);
        m_MainGameplay_Pause = m_MainGameplay.FindAction("Pause", throwIfNotFound: true);
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

    // MainGameplay
    private readonly InputActionMap m_MainGameplay;
    private IMainGameplayActions m_MainGameplayActionsCallbackInterface;
    private readonly InputAction m_MainGameplay_Move;
    private readonly InputAction m_MainGameplay_Jump;
    private readonly InputAction m_MainGameplay_Teleport;
    private readonly InputAction m_MainGameplay_Interaction;
    private readonly InputAction m_MainGameplay_Pause;
    public struct MainGameplayActions
    {
        private @PlatformerControls m_Wrapper;
        public MainGameplayActions(@PlatformerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MainGameplay_Move;
        public InputAction @Jump => m_Wrapper.m_MainGameplay_Jump;
        public InputAction @Teleport => m_Wrapper.m_MainGameplay_Teleport;
        public InputAction @Interaction => m_Wrapper.m_MainGameplay_Interaction;
        public InputAction @Pause => m_Wrapper.m_MainGameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_MainGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IMainGameplayActions instance)
        {
            if (m_Wrapper.m_MainGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnJump;
                @Teleport.started -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnTeleport;
                @Interaction.started -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnInteraction;
                @Pause.started -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MainGameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MainGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MainGameplayActions @MainGameplay => new MainGameplayActions(this);
    public interface IMainGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
