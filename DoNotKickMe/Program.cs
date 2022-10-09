using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DoNotKickMe
{
    public static class Win32
    {
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr handle);

        [DllImport("User32.dll", EntryPoint = "mouse_event", CallingConvention = CallingConvention.Winapi)]
        public static extern void Mouse_Event(int flags,
                                              int dx,
                                              int dy,
                                              int data,
                                              int extraInfo);

        [DllImport("User32.dll", EntryPoint = "GetSystemMetrics", CallingConvention = CallingConvention.Winapi)]
        public static extern int InternalGetSystemMetrics(int value);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr handle,
                                             uint message,
                                             int wParam,
                                             int lParam);

        [DllImport("User32.dll")]
        public static extern int PostMessage(IntPtr handle,
                                             uint message,
                                             int wParam,
                                             int lParam);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint SendInput(uint inputsLength, Input[] data, int inputsSize);

        [DllImport("User32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("User32.dll")]
        public static extern short VkKeyScanA(char ch);

        [DllImport("User32.dll")]
        public static extern short MapVirtualKey(uint code, uint mapType);

        [DllImport("User32.dll")]
        public static extern IntPtr SetFocus(IntPtr handle);

        public enum MouseCommand : int
        {
            LeftButtonUp   = 0x0004,
            LeftButtonDown = 0x0002,
            SetPosition    = 0x0001 | 0x8000
        }

        public enum EventType : uint
        {
            Keydown = 0x100,
            KeyUp   = 0x101,
            Char    = 0x102
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort KeyCode;
            public ushort ScanCode;
            public uint   Flags;
            public uint   Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int    Dx;
            public int    Dy;
            public uint   MouseData;
            public uint   Flags;
            public uint   Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint   Message;
            public ushort ParamLow;
            public ushort ParamHigh;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput    MouseInput;
            [FieldOffset(0)] public KeyboardInput KeyboardInput;
            [FieldOffset(0)] public HardwareInput HardwareInput;
        }

        public struct Input
        {
            public int        Type;
            public InputUnion Union;
        }

        [Flags]
        public enum InputType
        {
            Mouse    = 0,
            Keyboard = 1,
            Hardware = 2,
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown     = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp       = 0x0002,
            Unicode     = 0x0004,
            Scancode    = 0x0008,
        }

        [Flags]
        public enum MouseEvent
        {
            Absolute       = 0x8000,
            HWheel         = 0x01000,
            Move           = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown       = 0x0002,
            LeftUp         = 0x0004,
            RightDown      = 0x0008,
            RightUp        = 0x0010,
            MiddleDown     = 0x0020,
            MiddleUp       = 0x0040,
            VirtualDesk    = 0x4000,
            Wheel          = 0x0800,
            XDown          = 0x0080,
            XUp            = 0x0100,
        }
    }

    public static class DirectX
    {
        public enum Keys : ushort
        {
            Escape             = 1,
            Num1               = 2,
            Num2               = 3,
            Num3               = 4,
            Num5               = 6,
            Num7               = 8,
            Num9               = 10,
            Num0               = 11,
            Minus              = 12,
            Equals             = 13,
            Backspace          = 14,
            Tab                = 15,
            Q                  = 16,
            W                  = 17,
            E                  = 18,
            R                  = 19,
            T                  = 20,
            Y                  = 21,
            U                  = 22,
            I                  = 23,
            O                  = 24,
            P                  = 25,
            LeftBracket        = 26,
            RightBracket       = 27,
            Enter              = 28,
            LeftControl        = 29,
            A                  = 30,
            S                  = 31,
            D                  = 32,
            F                  = 33,
            G                  = 34,
            H                  = 35,
            J                  = 36,
            K                  = 37,
            L                  = 38,
            Semicolon          = 39,
            Apostrophe         = 40,
            Tilde              = 41,
            LeftShift          = 42,
            BackSlash          = 43,
            Z                  = 44,
            X                  = 45,
            C                  = 46,
            V                  = 47,
            B                  = 48,
            N                  = 49,
            M                  = 50,
            Comma              = 51,
            Period             = 52,
            ForwardSlash       = 53,
            RightShift         = 54,
            NumpadAsterisk     = 55,
            LeftAlt            = 56,
            Spacebar           = 57,
            CapsLock           = 58,
            F1                 = 59,
            F2                 = 60,
            F3                 = 61,
            F4                 = 62,
            F5                 = 63,
            F6                 = 64,
            F7                 = 65,
            F8                 = 66,
            F9                 = 67,
            F10                = 68,
            NumLock            = 69,
            ScrollLock         = 70,
            Numpad7            = 71,
            Numpad8            = 72,
            Numpad9            = 73,
            NumpadMinus        = 74,
            Numpad4            = 75,
            Numpad5            = 76,
            Numpad6            = 77,
            NumpadPlus         = 78,
            Numpad1            = 79,
            Numpad2            = 80,
            Numpad3            = 81,
            Numpad0            = 82,
            NumpadDot          = 83,
            F11                = 87,
            F12                = 88,
            NumpadEnter        = 156,
            RightControl       = 157,
            NumpadForwardSlash = 181,
            RightAlt           = 184,
            Home               = 199,
            UpArrow            = 200,
            PageUp             = 201,
            LeftArrow          = 203,
            RightArrow         = 205,
            End                = 207,
            DownArrow          = 208,
            PageDown           = 209,
            Insert             = 210,
            Delete             = 211,
            LeftMouseButton    = 256,
            RightMouseButton   = 257,
            MiddleMouse        = 258,
            MouseButton3       = 259,
            MouseButton4       = 260,
            MouseButton5       = 261,
            MouseButton6       = 262,
            MouseButton7       = 263,
            MouseWheelUp       = 264,
            MouseWheelDown     = 265
        }
    }

    public enum KeyState : byte
    {
        Down = 0,
        Up
    }

    public sealed class VirtualHid
    {
        #region Fields
        private readonly Process targetProcess;
        #endregion

        public VirtualHid(Process targetProcess)
            => this.targetProcess = targetProcess ?? throw new ArgumentNullException(nameof(targetProcess));
            
        public void SendText(string keys)
        {
            Win32.SetForegroundWindow(targetProcess.MainWindowHandle);

            SendKeys.SendWait(keys);
        }

        public void SendKey(ushort key, KeyState state)
        {
            Win32.SetForegroundWindow(targetProcess.MainWindowHandle);
            Win32.SetFocus(targetProcess.MainWindowHandle);

            var input = new[]
            {
                new Win32.Input
                {
                    Type = (int)Win32.InputType.Keyboard,
                    Union = new Win32.InputUnion
                    {
                        KeyboardInput = new Win32.KeyboardInput
                        {
                            ScanCode  = key,
                            Flags     = (uint)((state == KeyState.Down ? Win32.KeyEventF.KeyDown : Win32.KeyEventF.KeyUp) | Win32.KeyEventF.Scancode),
                            ExtraInfo = Win32.GetMessageExtraInfo(),
                        },
                    },
                },
            };

            Win32.SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Win32.Input)));
        }
    }
    
    public static class Program
    {
        #region Fields
        private static readonly TimeSpan KeyPressDelayFluctuation = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan AntiAfkInputDelay        = TimeSpan.FromMinutes(19.5);
        private static readonly TimeSpan AntiAfkInputFluctuation  = TimeSpan.FromMinutes(9.5);
        
        private static readonly DirectX.Keys[] AntiAfkKeys = 
        {
            DirectX.Keys.W,
            DirectX.Keys.A,
            DirectX.Keys.S,
            DirectX.Keys.D,
            DirectX.Keys.Spacebar,
            DirectX.Keys.Escape,
        };
        #endregion

        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Missing required argument process name");

                return;
            }

            var processName = args[0];
            var process     = Process.GetProcessesByName(processName).FirstOrDefault();

            if (process == null)
            {
                Console.WriteLine($"Could not find processes with name {processName}");
                
                return;
            }

            Console.WriteLine("Keeping you connected!");
            
            var hid    = new VirtualHid(process);
            var random = new Random();
            
            for (;;)
            {
                var key           = AntiAfkKeys[random.Next(0, AntiAfkKeys.Length - 1)];
                var keyPressDelay = TimeSpan.FromSeconds(KeyPressDelayFluctuation.TotalSeconds * random.NextDouble());
                var inputDelay    = TimeSpan.FromSeconds(AntiAfkInputDelay.TotalSeconds + AntiAfkInputFluctuation.TotalSeconds * random.NextDouble());
                
                Console.WriteLine("Just letting you know that I'm sending out a key stroke to keep you connected!");
                Console.WriteLine($"\tSending out key {Enum.GetName(typeof(DirectX.Keys), key)}");
                Console.WriteLine($"\tI will hold it down for {keyPressDelay.TotalSeconds:0.00}s");
                
                hid.SendKey((ushort)key, KeyState.Down);
                
                Thread.Sleep(keyPressDelay);
                
                hid.SendKey((ushort)key, KeyState.Up);

                Console.WriteLine("Key pressed and released");
                Console.WriteLine($"\tI will send out the next key press in {inputDelay.TotalMinutes:00}:{inputDelay.Seconds:00}m");
                
                Thread.Sleep(inputDelay);
            }
        }
    }
}