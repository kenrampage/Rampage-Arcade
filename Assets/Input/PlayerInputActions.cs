// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""e8e02193-dc99-418f-9564-1671ba9d3f6d"",
            ""actions"": [
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""63fee75a-b884-4070-bea9-f4523feb11ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""84672462-3f7a-46ad-833b-49d1156b7816"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""81690002-1183-42f4-89a4-39d4bd888e03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a70b6f94-8dd6-4890-887f-f6935d0c57f4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eda27e14-064b-4cc1-be17-834063d50771"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard WASD"",
                    ""id"": ""e6961d4c-8414-47f3-be22-5d668a3ac5c2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""d6e2e144-139c-46e9-8d0b-0860fe822b4c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""5f8b2141-4436-4a5f-9197-fed8ce3f55df"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad Left Stick"",
                    ""id"": ""7b8bced8-e491-418a-b375-7b15c81b5288"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""b310f0e8-f86b-4997-ad5d-6715eafc1869"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""eb3ded4f-4981-4cd8-bff5-b61d30402455"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad Dpad"",
                    ""id"": ""7a0e6af0-d0c0-459f-9f3e-70644caaab95"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""548f234f-acf2-4e60-818e-fa1d2e019dfd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""1a484541-c8e8-4a07-9181-6c2954c0b17b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard WASD"",
                    ""id"": ""bd295c83-4fe6-48d8-ab5f-133116b73040"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0813ecac-a665-475e-b932-f69c689a207e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fa6f588d-54ab-4435-9a1b-3968d801ad40"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""ff761c5e-628c-4dbd-835b-8995907a7e57"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ea2dd7dd-3f37-40b9-9d59-ad1d718fb357"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5b3b8416-cbf1-4e9b-8624-c99eb532d78f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""System"",
            ""id"": ""fd5719c6-407f-4731-a24e-a872a3355b35"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4cb070c8-2860-496a-87f0-011f61fbff66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""daf313b7-59f8-47a0-88c2-0d4fb6cf5c2b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0c89c21-c54c-44a2-a774-e80922c7ee77"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""a1067f88-b862-4b4a-8932-c3c4919c1f9e"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""d7759584-5cd5-442d-a317-36fd6ecd23df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""1ea10993-10c7-4bf2-83ed-243b82c91420"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""45767195-8e02-478a-949e-33711e2aac01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""85b6ac30-f0b2-4e02-bb94-38a1eb50992d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdb4c996-60fc-4810-8a12-8c594aa84aee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""08bd1f05-cfdb-4187-8b2d-e7ffec940c65"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""55a812ee-d6f4-4071-9aa9-6448d391055c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1af5297-5326-4e85-9dc5-41d21564350f"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d4535881-7471-4776-b790-8416953a6afa"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0f2bf6bc-c8b4-43e6-9177-4c322c0e4639"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""20bab03c-da8d-4b79-af99-a3b2d974c963"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dae84cd3-7fb3-41ec-bb7b-e9dd0ce323de"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65d813cc-1be2-4b34-af96-b097cc993caa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6c72de95-fee7-4fc8-8f22-2209edc92c9f"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0220f1f1-499c-4737-ba61-6c27a0492af5"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""664be275-82e5-429b-be81-cd56af404d0c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""66374329-de50-4da4-9687-ad21ba5953c4"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6a9e0c0d-c4fb-468c-bdc0-73469565f1b9"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1afccc36-d8f8-4a77-994c-06223eea9594"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""83244178-cdd0-4d75-8acd-3badad290dfb"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3e7d4057-cc23-468c-ab9c-cd1297bf5407"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1f2e9ee3-58ee-43c6-bba1-09fbab18b543"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a49f207-7034-4179-b30f-36ae8c8d86ca"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc075331-e94c-4211-a11a-d26b57f1986e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""245b3647-e54e-4f1d-ba3f-9d7dc14717db"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b527a826-dea3-49d2-be07-15fd8a9180e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""385c9f79-1a87-4b4e-8cae-ed61aaf8bb31"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98957d09-9b7e-42ac-ab63-3ae51fc88290"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5859ef44-32c0-4277-9b0e-2936628531e3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6de45825-f15e-4e85-9c0d-f08942f8b032"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3599f36c-9197-4469-8f26-ad0ec5167be8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d79d722-b5c1-444e-8974-fcafaaffd7e6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""168a5219-b6ac-44b3-9c21-affc9be4a1a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df6d2097-b9a6-4b7b-928b-9e42d89b3b35"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39d954e8-1643-4c7c-95cb-60ff0fc6c452"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;KBM"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1bc2f09-9edc-4224-9df0-c9ea57e4bf60"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a2a77ed-64aa-45e4-a5e6-f601811a8f18"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Runner"",
            ""id"": ""e708e86d-72b7-4a85-8b66-d8a59cb1445d"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""abd0ea2a-200c-4daf-b8eb-ec9edef9d7ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f85fb53c-4d23-4970-8c4b-e71c91bc61ea"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b27745c-a5f6-4f78-ae2b-7cdc32946a44"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TopDownShooter"",
            ""id"": ""e760775a-f46d-4a91-bb12-a573df5f9502"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e2918734-8ec5-4eb3-b2dd-2437a7d9301f"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""cd161d99-98ef-477b-b828-77acc258e45e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""cadfe1fb-dd07-4d13-972a-769ab4491ab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""d34f0336-9836-40f9-90ea-561a135d97dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GamepadAim"",
                    ""type"": ""Value"",
                    ""id"": ""d63de93a-0319-400e-8065-4b9a6014b8fa"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard WASD"",
                    ""id"": ""1b421d9e-0f97-4ecb-888f-005e396d117b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4e7b312c-4bdf-452c-b318-6c12bf29e56c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8bb72f97-2266-4934-9cef-c81279cf4516"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad Left Stick"",
                    ""id"": ""a27d9229-5c0f-428c-a523-0e1871278c49"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""91217d33-0e8c-408f-8339-22c01e98afbe"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""424521e6-7902-43aa-9906-d3893275e186"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad Dpad"",
                    ""id"": ""b754ca2b-18a3-461c-9e9f-64206c2258ba"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6955d5c4-92bf-4fd5-922d-d72988d86141"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3c8fb1b1-5efc-4075-820d-7d648933cc31"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2ca32aca-cc2e-4c25-acb6-49da879d5a87"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7250eabb-8f30-4397-9e18-a2bde1b809b6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d3cbb4f-48a9-4f8b-b474-05287a54f3f7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf7cbfd4-61e9-4982-b945-d824bd712633"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d697fb77-2677-489e-8970-dc4c9c0e1025"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4542c9f8-b625-40f7-b89f-e126bcd2a157"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08f298f4-418c-422d-8908-bfe459a0ac0c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""GamepadAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Brake = m_Car.FindAction("Brake", throwIfNotFound: true);
        m_Car_Turn = m_Car.FindAction("Turn", throwIfNotFound: true);
        m_Car_Accelerate = m_Car.FindAction("Accelerate", throwIfNotFound: true);
        // System
        m_System = asset.FindActionMap("System", throwIfNotFound: true);
        m_System_Pause = m_System.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        // Runner
        m_Runner = asset.FindActionMap("Runner", throwIfNotFound: true);
        m_Runner_Jump = m_Runner.FindAction("Jump", throwIfNotFound: true);
        // TopDownShooter
        m_TopDownShooter = asset.FindActionMap("TopDownShooter", throwIfNotFound: true);
        m_TopDownShooter_Move = m_TopDownShooter.FindAction("Move", throwIfNotFound: true);
        m_TopDownShooter_Fire = m_TopDownShooter.FindAction("Fire", throwIfNotFound: true);
        m_TopDownShooter_Reload = m_TopDownShooter.FindAction("Reload", throwIfNotFound: true);
        m_TopDownShooter_MouseAim = m_TopDownShooter.FindAction("MouseAim", throwIfNotFound: true);
        m_TopDownShooter_GamepadAim = m_TopDownShooter.FindAction("GamepadAim", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Brake;
    private readonly InputAction m_Car_Turn;
    private readonly InputAction m_Car_Accelerate;
    public struct CarActions
    {
        private @PlayerInputActions m_Wrapper;
        public CarActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Brake => m_Wrapper.m_Car_Brake;
        public InputAction @Turn => m_Wrapper.m_Car_Turn;
        public InputAction @Accelerate => m_Wrapper.m_Car_Accelerate;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Brake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Turn.started -= m_Wrapper.m_CarActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnTurn;
                @Accelerate.started -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
            }
        }
    }
    public CarActions @Car => new CarActions(this);

    // System
    private readonly InputActionMap m_System;
    private ISystemActions m_SystemActionsCallbackInterface;
    private readonly InputAction m_System_Pause;
    public struct SystemActions
    {
        private @PlayerInputActions m_Wrapper;
        public SystemActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_System_Pause;
        public InputActionMap Get() { return m_Wrapper.m_System; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SystemActions set) { return set.Get(); }
        public void SetCallbacks(ISystemActions instance)
        {
            if (m_Wrapper.m_SystemActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_SystemActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_SystemActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_SystemActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_SystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public SystemActions @System => new SystemActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Runner
    private readonly InputActionMap m_Runner;
    private IRunnerActions m_RunnerActionsCallbackInterface;
    private readonly InputAction m_Runner_Jump;
    public struct RunnerActions
    {
        private @PlayerInputActions m_Wrapper;
        public RunnerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Runner_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Runner; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RunnerActions set) { return set.Get(); }
        public void SetCallbacks(IRunnerActions instance)
        {
            if (m_Wrapper.m_RunnerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_RunnerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_RunnerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_RunnerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_RunnerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public RunnerActions @Runner => new RunnerActions(this);

    // TopDownShooter
    private readonly InputActionMap m_TopDownShooter;
    private ITopDownShooterActions m_TopDownShooterActionsCallbackInterface;
    private readonly InputAction m_TopDownShooter_Move;
    private readonly InputAction m_TopDownShooter_Fire;
    private readonly InputAction m_TopDownShooter_Reload;
    private readonly InputAction m_TopDownShooter_MouseAim;
    private readonly InputAction m_TopDownShooter_GamepadAim;
    public struct TopDownShooterActions
    {
        private @PlayerInputActions m_Wrapper;
        public TopDownShooterActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TopDownShooter_Move;
        public InputAction @Fire => m_Wrapper.m_TopDownShooter_Fire;
        public InputAction @Reload => m_Wrapper.m_TopDownShooter_Reload;
        public InputAction @MouseAim => m_Wrapper.m_TopDownShooter_MouseAim;
        public InputAction @GamepadAim => m_Wrapper.m_TopDownShooter_GamepadAim;
        public InputActionMap Get() { return m_Wrapper.m_TopDownShooter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopDownShooterActions set) { return set.Get(); }
        public void SetCallbacks(ITopDownShooterActions instance)
        {
            if (m_Wrapper.m_TopDownShooterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnReload;
                @MouseAim.started -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMouseAim;
                @MouseAim.performed -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMouseAim;
                @MouseAim.canceled -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnMouseAim;
                @GamepadAim.started -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnGamepadAim;
                @GamepadAim.performed -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnGamepadAim;
                @GamepadAim.canceled -= m_Wrapper.m_TopDownShooterActionsCallbackInterface.OnGamepadAim;
            }
            m_Wrapper.m_TopDownShooterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @MouseAim.started += instance.OnMouseAim;
                @MouseAim.performed += instance.OnMouseAim;
                @MouseAim.canceled += instance.OnMouseAim;
                @GamepadAim.started += instance.OnGamepadAim;
                @GamepadAim.performed += instance.OnGamepadAim;
                @GamepadAim.canceled += instance.OnGamepadAim;
            }
        }
    }
    public TopDownShooterActions @TopDownShooter => new TopDownShooterActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface ICarActions
    {
        void OnBrake(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
    }
    public interface ISystemActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IRunnerActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ITopDownShooterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
        void OnGamepadAim(InputAction.CallbackContext context);
    }
}
