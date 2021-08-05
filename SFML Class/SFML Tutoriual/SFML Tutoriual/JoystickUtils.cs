using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    public enum JoystickType { XBOX360, PS4 };

    public enum GameButtons 
    {
        MainButtonDown,
        MainButtonRight,
        MainButtonUp,
        MainButtonLeft,
        LeftButton,
        RightButton,
        ExtraLeftButton,
        ExtraRightButton,
        LeftStickButton,
        RightStickButton
    }

    public static class JoystickUtils
    {
        private static float drift = 0.1f;

        public static void SetDrift(float newDriftValue)
        {
            drift = newDriftValue;
        }

        public static float GetAxis(uint joystickID, Joystick.Axis axis)
        {
            return ((Joystick.GetAxisPosition(joystickID, axis) / 100.0f) >= drift || (Joystick.GetAxisPosition(joystickID, axis) / 100.0f) <= -drift)
                ? Joystick.GetAxisPosition(joystickID, axis) / 100.0f : 0.0f;
        }

        public static uint GetButton(JoystickType type, GameButtons button) 
        {
            switch (type)
            {
                case JoystickType.XBOX360:
                    {
                        switch (button)
                        {
                            case GameButtons.MainButtonDown:
                                return 0;
                            case GameButtons.MainButtonRight:
                                return 1;
                            case GameButtons.MainButtonUp:
                                return 2;
                            case GameButtons.MainButtonLeft:
                                return 3;
                            case GameButtons.LeftButton:
                                return 4;
                            case GameButtons.RightButton:
                                return 5;
                            case GameButtons.ExtraLeftButton:
                                return 6;
                            case GameButtons.ExtraRightButton:
                                return 7;
                            case GameButtons.LeftStickButton:
                                return 8;
                            case GameButtons.RightStickButton:
                                return 9;
                            default:
                                break;
                        }
                    }
                    break;
                case JoystickType.PS4:
                    {
                        switch (button)
                        {
                            case GameButtons.MainButtonDown:
                                return 1;
                            case GameButtons.MainButtonRight:
                                return 2;
                            case GameButtons.MainButtonUp:
                                return 0;
                            case GameButtons.MainButtonLeft:
                                return 3;
                            case GameButtons.LeftButton:
                                break;
                            case GameButtons.RightButton:
                                break;
                            case GameButtons.ExtraLeftButton:
                                break;
                            case GameButtons.ExtraRightButton:
                                break;
                            case GameButtons.LeftStickButton:
                                break;
                            case GameButtons.RightStickButton:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return uint.MaxValue;
        }

    }
}
