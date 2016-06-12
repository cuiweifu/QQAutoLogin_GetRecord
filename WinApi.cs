using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsAPI
{
    /// <summary>
    /// WinApi����
    /// </summary>
    public class WinApi
    {
        /// <summary>
        /// Hook���� ί��
        /// </summary>
        /// <param name="nCode">Hook����</param>
        /// <param name="wParam"></param>
        /// <param name="iParam"></param>
        /// <returns></returns>
        public delegate int HookProc(Int32 nCode, IntPtr wParam, IntPtr iParam);

        /// <summary>
        /// ��װ����
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpfm"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SetWindowsHookEx(Int32 idHook, HookProc lpfm, IntPtr hInstance, Int32 threadId);

        /// <summary>
        /// ж�ع���
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 UnhookWindowsHookEx(Int32 idHook);

        /// <summary>
        /// ��һ������
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="iParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 CallNextHookEx(Int32 idHook, Int32 nCode, IntPtr wParam, IntPtr iParam);

        /// <summary>
        /// ����ƶ�����ȶ���
        /// </summary>
        /// <param name="dwFlags">�ײ���������ϸ����</param>
        /// <param name="dx">ָ�������x��ľ���λ�û��ߴ��ϴ�����¼����������ƶ���������������MOUSEEVENTF_ABSOLUTE�����á������ľ���������Ϊ����ʵ��X���ꣻ���������������Ϊ�ƶ���mickeys����һ��mickey��ʾ����ƶ�����������������Ѿ��ƶ���</param>
        /// <param name="dy">ָ�������y��ľ���λ�û��ߴ��ϴ�����¼����������ƶ���������������MOUSEEVENTF_ABSOLUTE�����á������ľ���������Ϊ����ʵ��y���꣬���������������Ϊ�ƶ���mickeys����</param>
        /// <param name="cButtons">���dwFlagsΪMOUSEEVENTF_WHEEL����dwDataָ��������ƶ�����������ֵ�����������ǰת������Զ���û��ķ��򣻸�ֵ������������ת�����������û���һ���ֻ�����ΪWHEEL_DELTA����120�����dwFlagsS����MOUSEEVENTF_WHEEL����dWDataӦΪ�㡣</param>
        /// <param name="dwExtraInfo">ָ��������¼���صĸ���32λֵ��Ӧ�ó�����ú���GetMessageExtraInfo����ô˸�����Ϣ��</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// ģ����̲���
        /// </summary>
        /// <param name="Keybd_vk">�����������ֵ</param>
        /// <param name="dwData">ɨ���룬һ�㲻�����ã���0�������</param>
        /// <param name="dwFlags">ѡ���־�����Ϊkeydown����0���ɣ��ײ���������ϸ����(mouse_eventע��)</param>
        /// <param name="dwExtraInfo">һ����Ϊ0</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern void keybd_event(int Keybd_vk, int bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32")]
        public static extern void keybd_event(Keys key, int bScan, int dwFlags, int dwExtraInfo);

        /// <summary>
        /// �������λ�û�ȡ����
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point lpPoint);

        /// <summary>
        /// ��ȡ���λ��
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(out Point lpPoint);

        /// <summary>
        /// ��������λ�á�������ƶ���ָ����λ��
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetCursorPos(Point lpPoint);

        /// <summary>
        /// ��ȡ����ľ��
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// ��ȡ���λ���µĴ���
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetLocalWindow()
        {
            Point point;
            GetCursorPos(out point);
            return WindowFromPoint(point);
        }

        /// <summary>
        /// ���ظ������а�����ָ����ĵ�һ���Ӵ��ڵľ�� hWndParent:
        /// ��ע��ϵͳ��һ����ĳһ����������ϵ�������Ӵ��ڵ��ڲ��б��б��еľ��˳��������Щ�Ӵ��ڵ�Z������ж���һ�����Ӵ��ڰ����õ㣬��ôϵͳ�������б��а����õ㲢��������uFlags����Ĺ���ĵ�һ�����ڵľ����
        /// </summary>
        /// <param name="pHwnd">�����ھ��</param>
        /// <param name="pt">ָ��һ��POINT�ṹ���ýṹ�����˱����ĵ������</param>
        /// <param name="uFlgs">ָ�����Ե��Ӵ��ڵ����͡��ò������������в��������</param>
        /// <returns>����ֵΪ�����õ㲢��������uFlags����Ĺ���ĵ�һ���Ӵ��ڵľ��������õ��ڸ������ڣ�������һ�����������Ӵ����⣬�򷵻�ֵΪ�����ھ��������õ��ڸ�����֮�����ʧ�ܣ��򷵻�ֵΪNULL��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr pHwnd, LPPOINT pt, uint uFlgs);

        /// <summary>
        /// ��ȡ���ڴ�С��λ��
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="IpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT IpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;//��������
            public int Top;//��������
            public int Right;//��������
            public int Bottom;//��������
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                this.Left = Left;
                this.Top = Top;
                this.Right = Right;
                this.Bottom = Bottom;
            }

            public RECT(System.Drawing.Rectangle rectangle)
            {
                Left = rectangle.Left;
                Top = rectangle.Top;
                Right = rectangle.Right;
                Bottom = rectangle.Bottom;
            }

            public RECT(System.Drawing.Point location, System.Drawing.Size size)
            {
                Left = location.X;
                Top = location.Y;
                Right = location.X + size.Width;
                Bottom = location.Y + size.Height;
            }
        }

        /// <summary>
        /// ����Ļ����ת������Ե�ǰ���������  
        /// </summary>
        /// <param name="hWnd">ָ�򴰿ڵľ�����˴��ڵ��û��ռ佫������ת��</param>
        /// <param name="lpPoint">������Ե�ǰ���������</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, out LPPOINT lpPoint);

        /// <summary>
        /// �ѵ�ǰ���������ת��Ϊ��Ļ����
        /// </summary>
        /// <param name="hWnd">�û���������ת���Ĵ��ھ��</param>
        /// <param name="lpPoint">������Ļ����</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, out LPPOINT lpPoint);

        //Ҫת����������Ϣ�Ľṹ��
        [StructLayout(LayoutKind.Sequential)]
        public struct LPPOINT
        {
            public int x;
            public int y;
            public LPPOINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// �����Ƿ�ɼ�
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "IsWindowVisible")]
        public static extern int IsWindowVisible(int hWnd);

        /// <summary>
        /// ��ȡ�������Ƴ���
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "GetWindowTextLength")]
        public static extern int GetWindowTextLength(int hWnd);

        /// <summary>
        /// ��ȡ�������Ƴ���
        ///SW_FORCEMINIMIZE����WindowNT5.0����С�����ڣ���ʹӵ�д��ڵ��̱߳�����Ҳ����С�����ڴ������߳���С������ʱ��ʹ�����������
        ///SW_MIOE�����ش��ڲ������������ڡ�
        ///SW_MAXIMIZE�����ָ���Ĵ��ڡ�
        ///SW_MINIMIZE����С��ָ���Ĵ��ڲ��Ҽ�����Z���е���һ�����㴰�ڡ�
        ///SW_RESTORE�������ʾ���ڡ����������С������󻯣���ϵͳ�����ڻָ���ԭ���ĳߴ��λ�á��ڻָ���С������ʱ��Ӧ�ó���Ӧ��ָ�������־��
        ///SW_SHOW���ڴ���ԭ����λ����ԭ���ĳߴ缤�����ʾ���ڡ�
        ///SW_SHOWDEFAULT��������STARTUPINFO�ṹ��ָ����SW_FLAG��־�趨��ʾ״̬��STARTUPINFO �ṹ��������Ӧ�ó���ĳ��򴫵ݸ�CreateProcess�����ġ�
        ///SW_SHOWMAXIMIZED������ڲ�������󻯡�
        ///SW_SHOWMINIMIZED������ڲ�������С����
        ///SW_SHOWMINNOACTIVATE��������С�����������Ȼά�ּ���״̬��
        ///SW_SHOWNA���Դ���ԭ����״̬��ʾ���ڡ��������Ȼά�ּ���״̬��
        ///SW_SHOWNOACTIVATE���Դ������һ�εĴ�С��״̬��ʾ���ڡ��������Ȼά�ּ���״̬��
        ///SW_SHOWNOMAL�������ʾһ�����ڡ�������ڱ���С������󻯣�ϵͳ����ָ���ԭ���ĳߴ�ʹ�С��Ӧ�ó����ڵ�һ����ʾ���ڵ�ʱ��Ӧ��ָ���˱�־��
        /// ����ֵ�����������ǰ�ɼ����򷵻�ֵΪ���㡣���������ǰ�����أ��򷵻�ֵΪ�㡣
        /// ��ע��Ӧ�ó����һ�ε���ShowWindowʱ��Ӧ��ʹ��WinMain������nCmdshow������Ϊ����nCmdShow��������������ShowWindow����ʱ������ʹ���б��е�һ������ֵ����������WinMain������nCmdSHow����ָ����ֵ��
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow">0���رմ��ڣ�1��������С��ʾ���ڣ�2����С�����ڣ�3����󻯴���</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SetActiveWindow")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        /// <summary>
        /// �����ڷ�����ǰ��
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// ������/������Ҵ���
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// �ڴ����б���Ѱ����ָ����������ĵ�һ���Ӵ���
        /// </summary>
        /// <param name="hwndParent">�����ھ�������hwndParentΪ 0 �����������洰��Ϊ�����ڣ��������洰�ڵ������Ӵ��ڡ�</param>
        /// <param name="hwndChildAfter">�Ӵ��ھ�������Ҵ���Z���е���һ���Ӵ��ڿ�ʼ���Ӵ��ڱ���ΪhwndParent���ڵ�ֱ���Ӵ��ڶ��Ǻ�����ڡ����HwndChildAfterΪNULL�����Ҵ�hwndParent�ĵ�һ���Ӵ��ڿ�ʼ�����hwndParent �� hwndChildAfterͬʱΪNULL�������������еĶ��㴰�ڼ���Ϣ���ڡ�</param>
        /// <param name="lpszClass">�ؼ�����</param>
        /// <param name="lpszWindow">�ؼ����⣬����ò���Ϊ NULL����Ϊ���д���ȫƥ�䡣</param>
        /// <returns>�ؼ����</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //�ص�������EnumChildWindows ������
        public delegate bool CallBack(IntPtr hwnd, int lParam);
        /// <summary>
        /// ö��һ�������ڵ������Ӵ���
        /// ע�⣺�ص������ķ���ֵ����Ӱ�쵽���API��������Ϊ������ص���������true����ö�ټ���ֱ��ö����ɣ��������false���򽫻���ֹö�١�
        /// ����CallBack��������һ��ί�У�public delegate bool CallBack(IntPtr hwnd, int lParam); ��� CallBack ���ص���true��������ö�٣�����ͻ���ֹö�١�
        /// </summary>
        /// <param name="hWndParent">�����ھ��</param>
        /// <param name="lpfn">�ص������ĵ�ַ</param>
        /// <param name="lParam">�Զ���Ĳ���</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);

        /// <summary>
        /// ����windows��Ϣ
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// ����windows��Ϣ
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        /// <summary>
        /// ����windows��Ϣ
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, string lParam);

        /// <summary>
        /// ����windows��Ϣ
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// ����windows��Ϣ
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, System.Text.StringBuilder lParam);

        /// <summary>
        /// ȡ��һ������ı��⣨caption�����֣�����һ���ؼ�������
        /// </summary>
        /// <param name="hwnd">���ھ��</param>
        /// <param name="lpString">�����ı��Ļ�������ָ��</param>
        /// <param name="cch">ָ����������С, ���а���NULL�ַ�; ����ı��������ᱻ���ض�</param>
        /// <returns>�����ַ�����, �������жϵĿ��ַ�; �������Ϊ�ջ�����Ч, �򷵻���</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hwnd, System.Text.StringBuilder lpString, int cch);

        /// <summary>
        /// Ϊָ���Ĵ���ȡ������
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(IntPtr hwnd, System.Text.StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// �ú���������ʾ�����ش���ʱ���������������͵Ķ���Ч�������������ͻ���������
        /// </summary>
        /// <param name="hwnd">ָ�����������Ĵ��ڵľ����</param>
        /// <param name="dwTime">ָ������������ʱ�䣨��΢��ƣ������һ�������ı�׼ʱ��Ϊ200΢�롣</param>
        /// <param name="dwFags">ָ���������͡��������������һ���������б�־����ϡ���־������ </param>
        /// <returns></returns>
        /// �����
        /// 1������ʹ���˴��ڱ߽磻
        /// 2�������Ѿ��ɼ���Ҫ��ʾ���ڣ�
        /// 3�������Ѿ�������Ҫ���ش��ڡ�
        /// ������ʧ�ܡ�
        [DllImport("user32.dll")]
        public static extern void AnimateWindow(IntPtr hwnd, int dwTime, int dwFags);

        /// <summary>
        /// �ڴ�������ʱ��������Ч��
        /// </summary>
        /// <param name="hwnd">���ڵ�Handle</param>
        /// <param name="idAni">����Ч�����</param>
        /// <param name="lprcFrom">��ʼ���ھ���</param>
        /// <param name="lprcTo">����ʱ���ھ���</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool DrawAnimatedRects(System.IntPtr hwnd, int idAni, ref RECT lprcFrom, ref RECT lprcTo);

        /// <summary>
        /// �ú����ı�һ���Ӵ��ڣ�����ʽ����ʽ���㴰�ڵĳߴ磬λ�ú�Z�� ����
        /// �Ӵ��ڣ�����ʽ���ڣ������㴰�ڸ�����������Ļ�ϳ��ֵ�˳�����򡢶��㴰�����õļ�����ߣ����ұ�����ΪZ��ĵ�һ�����ڡ�
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="hWndAfter">��z���е�λ�ڱ���λ�Ĵ���ǰ�Ĵ��ھ�����ò�������Ϊһ�����ھ����������ֵ֮һ</param>
        /// <param name="x">�Կͻ�����ָ��������λ�õ���߽硣</param>
        /// <param name="y">�Կͻ�����ָ��������λ�õĶ��߽硣</param>
        /// <param name="cx">������ָ�����ڵ��µĿ�ȡ�</param>
        /// <param name="cy">������ָ�����ڵ��µĸ߶ȡ�</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint uflags);

        #region ע���ȼ�

        /// <summary>
        /// �������ִ�гɹ�������ֵ��Ϊ0��
        /// �������ִ��ʧ�ܣ�����ֵΪ0��Ҫ�õ���չ������Ϣ������GetLastError��
        /// </summary>
        /// <param name="hWnd">Ҫ�����ȼ��Ĵ��ڵľ��</param>
        /// <param name="id">�����ȼ�ID������������ID�ظ���</param>
        /// <param name="fsModifiers">��ʶ�ȼ��Ƿ��ڰ�Alt��Ctrl��Shift��Windows�ȼ�ʱ�Ż���Ч</param>
        /// <param name="vk"></param>
        /// <returns></return�����ȼ�������s>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// �������ִ�гɹ�������ֵ��Ϊ0��            
        /// �������ִ��ʧ�ܣ�����ֵΪ0��Ҫ�õ���չ������Ϣ������GetLastError��
        /// </summary>
        /// <param name="hWnd">Ҫ�����ȼ��Ĵ��ڵľ��</param>
        /// <param name="id">�����ȼ�ID������������ID�ظ���</param>
        /// <param name="fsModifiers">��ʶ�ȼ��Ƿ��ڰ�Alt��Ctrl��Shift��Windows�ȼ�ʱ�Ż���Ч</param>
        /// <param name="vk">�����ȼ�������</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, Keys vk);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// �����ȼ�
        /// </summary>
        /// <param name="hWnd">Ҫȡ���ȼ��Ĵ��ڵľ��</param>
        /// <param name="id">/Ҫȡ���ȼ���ID</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //�����˸����������ƣ�������ת��Ϊ�ַ��Ա��ڼ��䣬Ҳ��ȥ����ö�ٶ�ֱ��ʹ����ֵ��
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        #endregion

        /// <summary>
        /// ��ȡ��ǰ�̱߳��
        /// </summary>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern Int32 GetCurrentThreadId();

        /// <summary>
        /// ��ȡ����ָ��
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string Name);

        #region �ڴ����

        /// <summary>
        /// �����ڴ�ռ�
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpAddress"></param>
        /// <param name="dwSize"></param>
        /// <param name="flAllocationType"></param>
        /// <param name="flProtect"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern Int32 VirtualAllocEx(IntPtr hProcess, Int32 lpAddress, Int32 dwSize, Int16 flAllocationType, Int16 flProtect);

        /// <summary>
        /// ��ȡ�ڴ�ռ�
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern int ReadProcessMemory(IntPtr hProcess, Int32 lpBaseAddress, byte[] lpBuffer, long nSize, long lpNumberOfBytesWritten);

        /// <summary>
        /// д�ڴ�ռ�
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hProcess, Int32 lpBaseAddress, byte[] lpBuffer, long nSize, long lpNumberOfBytesWritten);

        #endregion

        #region Clipboard ���������
        
//        /// <summary>
//        /// �򿪼��а�
//        /// ÿ��ֻ����һ�����̴򿪲����ʡ�ÿ��һ�ξ�Ҫ�رգ��������������޷����ʼ��а塣
//        /// </summary>
//        /// <param name="hWndNewOwner">ָ���������򿪵ļ��а�Ĵ��ھ��������NULL��ʾ��������ǰ����</param>
//        /// <returns></returns>
//        [DllImport("user32.dll")]
//        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
         
//        /// <summary>
//        /// �رռ��а�
//        /// </summary>
//        [DllImport("user32.dll")]
//        public static extern bool CloseClipboard();

//        /// <summary>
//        /// ��ռ��а�����
//        /// </summary>
//        [DllImport("user32.dll")]
//        public static extern bool EmptyClipboard ();
        
///// <summary>
//        /// �����ڴ�
//        /// </summary>
//        [DllImport("user32.dll")]
//        public static extern HGLOBAL GlobalAlloc(UINT uFlags, SIZE_T dwBytes);
//  �ڶ��϶�̬�������ֽ�Ϊ��λ���ڴ����򡣳ɹ���ָ����ڴ棬ʧ��NULL��������1.�����ڴ����ԣ� 2.����Ĵ�С
//      �����ڴ�
//LPVOID GlobalLock(HGLOBAL hMem);
//  ������GlobalAlloc������ڴ棬�����ڴ���������������+1���ɹ�����ָ���ڴ������ʼ��ַ��ָ�롣ʧ��NULL

//ϵͳΪÿ��ȫ���ڴ����ά��һ����������������ʼΪ0��GlobalLockʹ������+1��GlobalUnLock������-1.һ��������ֵ����0��

//����ڴ����򽫲������ƶ���ɾ����ֻ�е�Ϊ0ʱ���Ž��������ڴ���������������ʱGMEM_FIXED���ԣ�������һֱΪ0

//GetClipboardData ��ȡ���а�����
//SetClipboardData ���ü��а�����
//IsClipboardFormatAvailable �жϼ��а�������Ƿ�Ϊĳ�ָ�ʽ
//CountClipboardFormats ��ȡ���а嵱ǰ�����ж���������
//EnumClipboardFormats ö�ټ��а��еĸ�ʽ
//GetClipboardFormatName ��ȡ���а�ĸ�ʽ������
//GetPriorityClipboardFormat ��ȡ��һ���б���ĳ�������ļ��а��ʽ
//RegisterClipboardFormat ע��(׷��)���а��ʽ
//�߼�Ӧ����ʹ�õĺ����������а���ӳ����ʱ��ʹ�ã�:
//ChangeClipboardChain �ı���а���������
//GetClipboardOwner ��ȡ���а�ĵ�ǰ�߾��
//GetClipboardViewer ��ȡ���а��ԭ����һ�������߾��
//SetClipboardViewer ׷�Ӽ��а�ļ����߾��
//GetOpenClipboardWindow ��ȡ�򿪼��а�ĵ�ǰ���ھ��
//GetClipboardSequenceNumber ��ȡ��ǰ�����ڼ��а����µ����к�

        #endregion

        /// <summary>
        /// SendMessageǰ��stringתΪbyte[]
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string InputStr)
        {
            byte[] ch = System.Text.Encoding.ASCII.GetBytes(InputStr);
            return ch;
        }

        public static bool IsChecked(IntPtr hWnd)
        {
            return WinApi.SendMessage(hWnd, BM_GETCHECK, 0, 0) == BST_CHECKED;
        }

        /// <summary>
        /// ������ʾ����DC 
        /// �磺CreateDC("DISPLAY", null, null, (IntPtr)null);
        /// </summary>
        /// <param name="lpszDriver">��������</param>
        /// <param name="lpszDevice">�豸����</param>
        /// <param name="lpszOutput">���ã������趨λ"NULL"</param>
        /// <param name="lpInitData">����Ĵ�ӡ������</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        /// <summary>
        /// ����ǰ��Ļ
        /// </summary>
        /// <param name="hdcDest">Ŀ���豸�ľ��</param>
        /// <param name="nXDest">Ŀ���������Ͻǵ�X����</param>
        /// <param name="nYDest">Ŀ���������Ͻǵ�X����</param>
        /// <param name="nWidth">Ŀ�����ľ��εĿ��</param>
        /// <param name="nHeight">Ŀ�����ľ��εĳ���</param>
        /// <param name="hdcSrc">Դ�豸�ľ��</param>
        /// <param name="nXSrc">Դ��������Ͻǵ�X����</param>
        /// <param name="nYSrc">Դ��������Ͻǵ�X����</param>
        /// <param name="dwRop">��դ�Ĳ���ֵ</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020, /* dest = source*/
            SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
            SRCAND = 0x008800C6, /* dest = source AND dest*/
            SRCINVERT = 0x00660046, /* dest = source XOR dest*/
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
            PATCOPY = 0x00F00021, /* dest = pattern*/
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
            DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
            BLACKNESS = 0x00000042, /* dest = BLACK*/
            WHITENESS = 0x00FF0062, /* dest = WHITE*/
        }

        #region  ����

        #region AnimateWindow dwFags

        /// <summary>
        /// ����������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԣ�
        /// </summary>
        public const Int32 AW_HOR_LEFT_RIGHT = 0x00000001;

        /// <summary>
        /// ����������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԣ�
        /// </summary>
        public const Int32 AW_HOR_RIGHT_LEFT = 0x00000002;

        /// <summary>
        /// �Զ�������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԣ�
        /// </summary>
        public const Int32 AW_VER_UP_DOWN = 0x00000004;

        /// <summary>
        /// ����������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԣ�
        /// </summary>
        public const Int32 AW_VER_DOWN_UP = 0x00000008;

        /// <summary>
        /// ��ʹ����AW_HIDE��־����ʹ���������ص������������ڣ���δʹ��AW_HIDE��־����ʹ����������չ����չ�����ڣ�
        /// </summary>
        public const Int32 AW_CENTER = 0x00000010;

        /// <summary>
        /// ���ش��ڣ�ȱʡ����ʾ���ڣ�
        /// </summary>
        public const Int32 AW_HIDE = 0x00010000;

        /// <summary>
        /// ����ڡ���ʹ����AW_HIDE��־����ʹ�������־��
        /// </summary>
        public const Int32 AW_ACTIVATE = 0x00020000;

        /// <summary>
        /// ʹ�û������͡�ȱʡ��Ϊ�����������͡���ʹ��AW_CENTER��־ʱ�������־�ͱ�����
        /// </summary>
        public const Int32 AW_SLIDE = 0x00040000;

        /// <summary>
        /// ʵ�ֵ���Ч����ֻ�е�hWndΪ���㴰�ڵ�ʱ��ſ���ʹ�ô˱�־��
        /// </summary>
        public const Int32 AW_BLEND = 0x00080000;

        #endregion

        #region ChildWindowFromPointEx uFlgs

        //���Բ��ɼ����Ӵ��ڡ�
        public const int CWP_SKIPINVISIBLE = 0x3;
        //���Բ������Ӵ���
        public const int CWP_SKIPDISABLED = 0x2;
        //�������صĻ�͸������
        public const int CWP_SKIPINVISIBL = 0x1;
        //��������һ�Ӵ���
        public const int CWP_All = 0x0;

        #endregion

        #region SetWindowPos  hWndInsertAfter

        //{��ǰ��}
        public const int HWND_TOP = 0;
        //{�ں���}
        public const int HWND_BOTTOM = 1;
        //{��ǰ��, λ���κζ������ڵ�ǰ��}
        public const int HWND_TOPMOST = -1;
        //{��ǰ��, λ�������������ڵĺ���}
        public const int HWND_NOTOPMOST = -2;

        #endregion

        #region SetWindowPos  uFlags

        //{���� cx��cy, ���ִ�С}
        public const int SWP_NOSIZE = 1;
        //{���� X��Y, ���ı�λ��}
        public const int SWP_NOMOVE = 2;
        //{���� hWndInsertAfter, ���� Z ˳��}
        public const int SWP_NOZORDER = 4;
        //{���ػ�}
        public const int SWP_NOREDRAW = 8;
        //{������}
        public const int SWP_NOACTIVATE = 10;
        //{ǿ�Ʒ��� WM_NCCALCSIZE ��Ϣ, һ��ֻ���ڸı��Сʱ�ŷ��ʹ���Ϣ}
        public const int SWP_FRAMECHANGED = 20;
        //{��ʾ����}
        public const int SWP_SHOWWINDOW = 40;
        //{���ش���}
        public const int SWP_HIDEWINDOW = 80;
        //{�����ͻ���}
        public const int SWP_NOCOPYBITS = 100;
        //{���� hWndInsertAfter, ���ı� Z ���е�������}
        public const int SWP_NOOWNERZORDER = 200;
        //{������ WM_WINDOWPOSCHANGING ��Ϣ}
        public const int SWP_NOSENDCHANGING = 400;
        //{���߿�}
        public const int SWP_DRAWFRAME = SWP_FRAMECHANGED;
        public const int SWP_NOREPOSITION = SWP_NOOWNERZORDER;
        //{��ֹ���� WM_SYNCPAINT ��Ϣ}
        public const int SWP_DEFERERASE = 2000;
        //{�����ý��̲�ӵ�д���, ϵͳ����ӵ�д��ڵ��̷߳�������}
        public const int SWP_ASYNCWINDOWPOS = 4000;

        #endregion

        #region  DrawAnimatedRects idAni

        public const System.Int32 IDANI_OPEN = 1;
        public const System.Int32 IDANI_CAPTION = 3;

        #endregion

        //�����
        public const int WM_CLICK = 0x00F5;
        public const int EM_SETSEL = 0x00B1;
        public const int EM_REPLACESEL = 0x00C2;

        //��ȡcheckbox�Ƿ�ѡ��
        public const int BM_GETCHECK = 0x00F0;
        //����checkboxѡ��
        public const int BM_SETCHECK = 0x00F1;
        //��ȡcheckbox״̬
        public const int BM_GETSTATE = 0x00F2;
        //checkboxѡ��
        public const int BST_CHECKED = 0x1;

        //�ƶ���� 
        public const int MOUSEEVENTF_MOVE = 0x0001;
        //ģ������������ 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //ģ��������̧�� 
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        //ģ������Ҽ����� 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //ģ������Ҽ�̧�� 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //ģ������м����� 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //ģ������м�̧�� 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //��ʾ�Ƿ���þ������� 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        /// <summary>
        /// values from Winuser.h in Microsoft SDK.
        /// Windows NT/2000/XP: Installs a hook procedure that monitors low-level mouse input events.
        /// </summary>
        public const int WH_MOUSE_LL = 14;

        /// <summary>
        /// Windows NT/2000/XP: Installs a hook procedure that monitors low-level keyboard  input events.
        /// </summary>
        public const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure. 
        /// </summary>
        public const int WH_MOUSE = 7;

        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure. 
        /// </summary>
        public const int WH_KEYBOARD = 2;

        //Shift��
        public const byte VK_SHIFT = 0x10;
        //CapsLock��
        public const byte VK_CAPITAL = 0x14;
        //NumLK��
        public const byte VK_NUMLOCK = 0x90;

        //����һ������
        public const int WM_CREATE = 0x01;
        //��һ�����ڱ��ƻ�ʱ����
        public const int WM_DESTROY = 0x02;
        //�ƶ�һ������
        public const int WM_MOVE = 0x03;
        //�ı�һ�����ڵĴ�С
        public const int WM_SIZE = 0x05;
        //һ�����ڱ������ʧȥ����״̬
        public const int WM_ACTIVATE = 0x06;
        //һ�����ڻ�ý���
        public const int WM_SETFOCUS = 0x07;
        //һ������ʧȥ����
        public const int WM_KILLFOCUS = 0x08;
        //һ�����ڸı��Enable״̬
        public const int WM_ENABLE = 0x0A;
        //���ô����Ƿ����ػ�
        public const int WM_SETREDRAW = 0x0B;
        //Ӧ�ó����ʹ���Ϣ������һ�����ڵ��ı�
        public const int WM_SETTEXT = 0x0C;
        //Ӧ�ó����ʹ���Ϣ�����ƶ�Ӧ���ڵ��ı���������
        public const int WM_GETTEXT = 0x0D;
        //�õ���һ�������йص��ı��ĳ��ȣ����������ַ���
        public const int WM_GETTEXTLENGTH = 0x0E;
        //Ҫ��һ�������ػ��Լ�
        public const int WM_PAINT = 0x0F;
        //��һ�����ڻ�Ӧ�ó���Ҫ�ر�ʱ����һ���ź�
        public const int WM_CLOSE = 0x10;
        //���û�ѡ������Ի��������Լ�����ExitWindows����
        public const int WM_QUERYENDSESSION = 0x11;
        //����������������
        public const int WM_QUIT = 0x12;
        //���û����ڻָ���ǰ�Ĵ�Сλ��ʱ���Ѵ���Ϣ���͸�ĳ��ͼ��
        public const int WM_QUERYOPEN = 0x13;
        //�����ڱ������뱻����ʱ�����ڴ��ڸı��Сʱ��
        public const int WM_ERASEBKGND = 0x14;
        //��ϵͳ��ɫ�ı�ʱ�����ʹ���Ϣ�����ж�������
        public const int WM_SYSCOLORCHANGE = 0x15;
        //��ϵͳ���̷���WM_QUERYENDSESSION��Ϣ�󣬴���Ϣ���͸�Ӧ�ó���֪ͨ���Ի��Ƿ����
        public const int WM_ENDSESSION = 0x16;
        //�����ػ���ʾ�����Ƿ��ʹ���Ϣ���������
        public const int WM_SHOWWINDOW = 0x18;
        //������Ϣ��Ӧ�ó����ĸ������Ǽ���ģ��ĸ��ǷǼ����
        public const int WM_ACTIVATEAPP = 0x1C;
        //��ϵͳ��������Դ��仯ʱ���ʹ���Ϣ�����ж�������
        public const int WM_FONTCHANGE = 0x1D;
        //��ϵͳ��ʱ��仯ʱ���ʹ���Ϣ�����ж�������
        public const int WM_TIMECHANGE = 0x1E;
        //���ʹ���Ϣ��ȡ��ĳ�����ڽ��е���̬��������
        public const int WM_CANCELMODE = 0x1F;
        //��������������ĳ���������ƶ����������û�б�����ʱ���ͷ���Ϣ��ĳ������
        public const int WM_SETCURSOR = 0x20;
        //�������ĳ���Ǽ���Ĵ����ж��û�����������ĳ�������ʹ���Ϣ��//��ǰ����
        public const int WM_MOUSEACTIVATE = 0x21;
        //���ʹ���Ϣ��MDI�Ӵ���//���û�����˴��ڵı���������//�����ڱ�����ƶ����ı��С
        public const int WM_CHILDACTIVATE = 0x22;
        //����Ϣ�ɻ��ڼ������ѵ�������ͣ�ͨ��WH_JOURNALPALYBACK��hook���������û�������Ϣ
        public const int WM_QUEUESYNC = 0x23;
        //����Ϣ���͸����ڵ�����Ҫ�ı��С��λ��
        public const int WM_GETMINMAXINFO = 0x24;
        //���͸���С�����ڵ���ͼ�꽫Ҫ���ػ�
        public const int WM_PAINTICON = 0x26;
        //����Ϣ���͸�ĳ����С�����ڣ���//�����ڻ�ͼ��ǰ���ı������뱻�ػ�
        public const int WM_ICONERASEBKGND = 0x27;
        //���ʹ���Ϣ��һ���Ի������ȥ���Ľ���λ��
        public const int WM_NEXTDLGCTL = 0x28;
        //ÿ����ӡ�����ж����ӻ����һ����ҵʱ��������Ϣ 
        public const int WM_SPOOLERSTATUS = 0x2A;
        //��button��combobox��listbox��menu�Ŀ�����۸ı�ʱ����
        public const int WM_DRAWITEM = 0x2B;
        //��button, combo box, list box, list view control, or menu item ������ʱ
        public const int WM_MEASUREITEM = 0x2C;
        //����Ϣ��һ��LBS_WANTKEYBOARDINPUT���ķ�������������������ӦWM_KEYDOWN��Ϣ 
        public const int WM_VKEYTOITEM = 0x2E;
        //����Ϣ��һ��LBS_WANTKEYBOARDINPUT�����б���͸���������������ӦWM_CHAR��Ϣ 
        public const int WM_CHARTOITEM = 0x2F;
        //�������ı�ʱ�����ʹ���Ϣ�õ��ؼ�Ҫ�õ���ɫ
        public const int WM_SETFONT = 0x30;
        //Ӧ�ó����ʹ���Ϣ�õ���ǰ�ؼ������ı�������
        public const int WM_GETFONT = 0x31;
        //Ӧ�ó����ʹ���Ϣ��һ��������һ���ȼ������ 
        public const int WM_SETHOTKEY = 0x32;
        //Ӧ�ó����ʹ���Ϣ���ж��ȼ���ĳ�������Ƿ��й���
        public const int WM_GETHOTKEY = 0x33;
        //����Ϣ���͸���С�����ڣ����˴��ڽ�Ҫ���ϷŶ���������û�ж���ͼ�꣬Ӧ�ó����ܷ���һ��ͼ�����ľ�������û��Ϸ�ͼ��ʱϵͳ��ʾ���ͼ�����
        public const int WM_QUERYDRAGICON = 0x37;
        //���ʹ���Ϣ���ж�combobox��listbox�����ӵ�������λ��
        public const int WM_COMPAREITEM = 0x39;
        //��ʾ�ڴ��Ѿ�������
        public const int WM_COMPACTING = 0x41;
        //���ʹ���Ϣ���Ǹ����ڵĴ�С��λ�ý�Ҫ���ı�ʱ��������setwindowpos�������������ڹ�����
        public const int WM_WINDOWPOSCHANGING = 0x46;
        //���ʹ���Ϣ���Ǹ����ڵĴ�С��λ���Ѿ����ı�ʱ��������setwindowpos�������������ڹ�����
        public const int WM_WINDOWPOSCHANGED = 0x47;
        //��ϵͳ��Ҫ������ͣ״̬ʱ���ʹ���Ϣ
        public const int WM_POWER = 0x48;
        //��һ��Ӧ�ó��򴫵����ݸ���һ��Ӧ�ó���ʱ���ʹ���Ϣ
        public const int WM_COPYDATA = 0x4A;
        //��ĳ���û�ȡ��������־����״̬���ύ����Ϣ������
        public const int WM_CANCELJOURNA = 0x4B;
        //��ĳ���ؼ���ĳ���¼��Ѿ�����������ؼ���Ҫ�õ�һЩ��Ϣʱ�����ʹ���Ϣ�����ĸ����� 
        public const int WM_NOTIFY = 0x4E;
        //���û�ѡ��ĳ���������ԣ����������Ե��ȼ��ı�
        public const int WM_INPUTLANGCHANGEREQUEST = 0x50;
        //��ƽ̨�ֳ��Ѿ����ı���ʹ���Ϣ����Ӱ����������
        public const int WM_INPUTLANGCHANGE = 0x51;
        //�������Ѿ���ʼ��windows��������ʱ���ʹ���Ϣ��Ӧ�ó���
        public const int WM_TCARD = 0x52;
        //����Ϣ��ʾ�û�������F1�����ĳ���˵��Ǽ���ģ��ͷ��ʹ���Ϣ���˴��ڹ����Ĳ˵�������ͷ��͸��н���Ĵ��ڣ����//��ǰ��û�н��㣬�ͰѴ���Ϣ���͸�//��ǰ����Ĵ���
        public const int WM_HELP = 0x53;
        //���û��Ѿ�������˳����ʹ���Ϣ�����еĴ��ڣ�//���û�������˳�ʱϵͳ�����û��ľ���������Ϣ�����û���������ʱϵͳ���Ϸ��ʹ���Ϣ
        public const int WM_USERCHANGED = 0x54;
        //���ÿؼ����Զ���ؼ������ǵĸ�����ͨ������Ϣ���жϿؼ���ʹ��ANSI����UNICODE�ṹ
        public const int WM_NOTIFYFORMAT = 0x55;
        //���û�ĳ�������е����һ���Ҽ��ͷ��ʹ���Ϣ���������
        public const int WM_CONTEXTMENU = 0x7B;//0x007B
        //������SETWINDOWLONG������Ҫ�ı�һ������ ���ڵķ��ʱ���ʹ���Ϣ���Ǹ�����
        public const int WM_STYLECHANGING = 0x7C;
        //������SETWINDOWLONG����һ������ ���ڵķ����ʹ���Ϣ���Ǹ�����
        public const int WM_STYLECHANGED = 0x7D;
        //����ʾ���ķֱ��ʸı���ʹ���Ϣ�����еĴ���
        public const int WM_DISPLAYCHANGE = 0x7E;
        //����Ϣ���͸�ĳ��������������ĳ�������й����Ĵ�ͼ���Сͼ��ľ��
        public const int WM_GETICON = 0x7F;
        //�����ʹ���Ϣ��һ���µĴ�ͼ���Сͼ����ĳ�����ڹ���
        public const int WM_SETICON = 0x80;
        //��ĳ�����ڵ�һ�α�����ʱ������Ϣ��WM_CREATE��Ϣ����ǰ����
        public const int WM_NCCREATE = 0x81;
        //����Ϣ֪ͨĳ�����ڣ��ǿͻ����������� 
        public const int WM_NCDESTROY = 0x82;
        //��ĳ�����ڵĿͻ�������뱻����ʱ���ʹ���Ϣ
        public const int WM_NCCALCSIZE = 0x83;
        //�ƶ���꣬��ס���ͷ����ʱ����
        public const int WM_NCHITTEST = 0x84;
        //�����ʹ���Ϣ��ĳ�����ڵ��������ڣ��Ŀ�ܱ��뱻����ʱ
        public const int WM_NCPAINT = 0x85;
        //����Ϣ���͸�ĳ�����ڽ������ķǿͻ�����Ҫ���ı�����ʾ�Ǽ���ǷǼ���״̬
        public const int WM_NCACTIVATE = 0x86;
        //���ʹ���Ϣ��ĳ����Ի����������Ŀؼ���widdows���Ʒ�λ����TAB��ʹ�������˿ؼ�ͨ��Ӧ
        public const int WM_GETDLGCODE = 0x87;
        //�������һ�����ڵķǿͻ������ƶ�ʱ���ʹ���Ϣ��������� �ǿͻ���Ϊ������ı��������� �ı߿���
        public const int WM_NCMOUSEMOVE = 0xA0;
        //�������һ�����ڵķǿͻ���ͬʱ����������ʱ�ύ����Ϣ
        public const int WM_NCLBUTTONDOWN = 0xA1;
        //���û��ͷ�������ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ 
        public const int WM_NCLBUTTONUP = 0xA2;
        //���û�˫��������ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        //���û���������Ҽ�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ
        public const int WM_NCRBUTTONDOWN = 0xA4;
        //���û��ͷ�����Ҽ�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ
        public const int WM_NCRBUTTONUP = 0xA5;
        //���û�˫������Ҽ�ͬʱ���ĳ�������ڷǿͻ���ʮ���ʹ���Ϣ
        public const int WM_NCRBUTTONDBLCLK = 0xA6;
        //���û���������м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ
        public const int WM_NCMBUTTONDOWN = 0xA7;
        //���û��ͷ�����м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ
        public const int WM_NCMBUTTONUP = 0xA8;
        //���û�˫������м�ͬʱ������ڴ��ڵķǿͻ���ʱ���ʹ���Ϣ
        public const int WM_NCMBUTTONDBLCLK = 0xA9;
        //WM_KEYDOWN ����һ����
        public const int WM_KEYDOWN = 0x0100;
        //�ͷ�һ����
        public const int WM_KEYUP = 0x0101;
        //����ĳ�������ѷ���WM_KEYDOWN�� WM_KEYUP��Ϣ
        public const int WM_CHAR = 0x102;
        //����translatemessage��������WM_KEYUP��Ϣʱ���ʹ���Ϣ��ӵ�н���Ĵ���
        public const int WM_DEADCHAR = 0x103;
        //���û���סALT��ͬʱ����������ʱ�ύ����Ϣ��ӵ�н���Ĵ���
        public const int WM_SYSKEYDOWN = 0x104;
        //���û��ͷ�һ����ͬʱALT ��������ʱ�ύ����Ϣ��ӵ�н���Ĵ���
        public const int WM_SYSKEYUP = 0x105;
        //��WM_SYSKEYDOWN��Ϣ��TRANSLATEMESSAGE����������ύ����Ϣ��ӵ�н���Ĵ���
        public const int WM_SYSCHAR = 0x106;
        //��WM_SYSKEYDOWN��Ϣ��TRANSLATEMESSAGE����������ʹ���Ϣ��ӵ�н���Ĵ���
        public const int WM_SYSDEADCHAR = 0x107;
        //��һ���Ի��������ʾǰ���ʹ���Ϣ������ͨ���ô���Ϣ��ʼ���ؼ���ִ����������
        public const int WM_INITDIALOG = 0x110;
        //���û�ѡ��һ���˵��������ĳ���ؼ�����һ����Ϣ�����ĸ����ڣ�һ����ݼ�������
        public const int WM_COMMAND = 0x111;
        //���û�ѡ�񴰿ڲ˵���һ�������//���û�ѡ����󻯻���С��ʱ�Ǹ����ڻ��յ�����Ϣ
        public const int WM_SYSCOMMAND = 0x112;
        //�����˶�ʱ���¼�
        public const int WM_TIMER = 0x113;
        //��һ�����ڱ�׼ˮƽ����������һ�������¼�ʱ���ʹ���Ϣ���Ǹ����ڣ�Ҳ���͸�ӵ�����Ŀؼ�
        public const int WM_HSCROLL = 0x114;
        //��һ�����ڱ�׼��ֱ����������һ�������¼�ʱ���ʹ���Ϣ���Ǹ�����Ҳ�����͸�ӵ�����Ŀؼ�
        public const int WM_VSCROLL = 0x115;
        //��һ���˵���Ҫ������ʱ���ʹ���Ϣ�����������û��˵����е�ĳ�����ĳ���˵������������������ʾǰ���Ĳ˵�
        public const int WM_INITMENU = 0x116;
        //��һ�������˵����Ӳ˵���Ҫ������ʱ���ʹ���Ϣ�����������������ʾǰ���Ĳ˵�������Ҫ�ı�ȫ��
        public const int WM_INITMENUPOPUP = 0x117;
        //���û�ѡ��һ���˵���ʱ���ʹ���Ϣ���˵��������ߣ�һ���Ǵ��ڣ�
        public const int WM_MENUSELECT = 0x11F;
        //���˵��ѱ������û�������ĳ��������ͬ�ڼ��ټ��������ʹ���Ϣ���˵���������
        public const int WM_MENUCHAR = 0x120;
        //��һ��ģ̬�Ի����˵��������״̬ʱ���ʹ���Ϣ�����������ߣ�һ��ģ̬�Ի����˵��������״̬�����ڴ�����һ��������ǰ����Ϣ��û����Ϣ�����ж��еȴ�
        public const int WM_ENTERIDLE = 0x121;
        //��windows������Ϣ��ǰ���ʹ���Ϣ����Ϣ��������ߴ��ڣ�ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ����������Ϣ����ı��ͱ�����ɫ
        public const int WM_CTLCOLORMSGBOX = 0x132;
        //��һ���༭�Ϳؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ�������ñ༭����ı��ͱ�����ɫ
        public const int WM_CTLCOLOREDIT = 0x133;
        //��һ���б��ؼ���Ҫ������ǰ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ���������б����ı��ͱ�����ɫ
        public const int WM_CTLCOLORLISTBOX = 0x134;
        //��һ����ť�ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ�������ð�Ŧ���ı��ͱ�����ɫ
        public const int WM_CTLCOLORBTN = 0x135;
        //��һ���Ի���ؼ���Ҫ������ǰ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ�������öԻ�����ı�������ɫ
        public const int WM_CTLCOLORDLG = 0x136;
        //��һ���������ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ���ͨ��ʹ�ø����������ʾ�豸�ľ�������ù������ı�����ɫ
        public const int WM_CTLCOLORSCROLLBAR = 0x137;
        //��һ����̬�ؼ���Ҫ������ʱ���ʹ���Ϣ�����ĸ�����ͨ����Ӧ������Ϣ�������ߴ��ڿ��� ͨ��ʹ�ø����������ʾ�豸�ľ�������þ�̬�ؼ����ı��ͱ�����ɫ
        public const int WM_CTLCOLORSTATIC = 0x138;
        //���������ת��ʱ���ʹ���Ϣ����ǰ�н���Ŀؼ�
        public const int WM_MOUSEWHEEL = 0x20A;
        //��������м�
        public const int WM_MBUTTONDOWN = 0x207;
        //�ͷ�����м�
        public const int WM_MBUTTONUP = 0x208;
        //˫������м�
        public const int WM_MBUTTONDBLCLK = 0x209;
        //�ƶ����ʱ������ͬWM_MOUSEFIRST
        public const int WM_MOUSEMOVE = 0x200;
        //����������
        public const int WM_LBUTTONDOWN = 0x201;
        //�ͷ�������
        public const int WM_LBUTTONUP = 0x202;
        //˫��������
        public const int WM_LBUTTONDBLCLK = 0x203;
        //��������Ҽ�
        public const int WM_RBUTTONDOWN = 0x204;
        //�ͷ�����Ҽ�
        public const int WM_RBUTTONUP = 0x205;
        //˫������Ҽ�
        public const int WM_RBUTTONDBLCLK = 0x206;
        //alt��
        public const int MOD_ALT = 0x0001;
        //ctrl��
        public const int MOD_CONTROl = 0x0002;
        //shift��
        public const int MOD_SHIFTl = 0x0004;
        //Windows��
        public const int MOD_WIN = 0x0008;
        //���ظ� Windows Vista and Windows XP/2000:  This flag is not supported.
        public const int MOD_NOREPEAT = 0x4000;
        //�ȼ�
        public const int WM_HOTKEY = 0x312;

        #endregion

        #region Virtual-Key Codes��

        public const int KEYEVENTF_KEYUP = 0x2;

        //public const int VK_LBUTTON	=1;	//Left mouse button
        //public const int VK_RBUTTON	=2;	//Right mouse button
        //public const int VK_CANCEL	=3;	//Control-break processing
        //public const int VK_MBUTTON	=4;	//Middle mouse button (three-button mouse)
        //public const int VK_XBUTTON1	=5;	//Windows 2000/XP: X1 mouse button
        //public const int VK_XBUTTON2	=6;	//Windows 2000/XP: X2 mouse button
        ////��	07	Undefined
        //public const int VK_BACK	=8;	//BACKSPACE key
        //public const int VK_TAB	=9;	//TAB key
        ////��	0A�C0B	Reserved
        //public const int VK_CLEAR	=0C;	//CLEAR key
        //public const int VK_RETURN	=0D;	//ENTER key
        ////��	0E�C0F	Undefined
        //public const int VK_SHIFT	=10;	//SHIFT key
        //public const int VK_CONTROL	=11;	//CTRL key
        //public const int VK_MENU	=12;	//ALT key
        //public const int VK_PAUSE	=13;	//PAUSE key
        //public const int VK_CAPITAL	=14;	//CAPS LOCK key
        //public const int VK_KANA	=15;	//IME Kana mode
        //public const int VK_HANGUEL	=15;	//IME Hanguel mode (maintained for compatibility; use VK_HANGUL)
        //public const int VK_HANGUL	=15;	//IME Hangul mode
        ////��	16	Undefined
        //public const int VK_JUNJA	=17	IME Junja mode
        //public const int VK_FINAL	=18	IME final mode
        //public const int VK_HANJA	=19	IME Hanja mode
        //public const int VK_KANJI	=19	IME Kanji mode
        ////��	1A	Undefined
        //public const int VK_ESCAPE	=1B	ESC key
        //public const int VK_CONVERT	=1C	IME convert
        //public const int VK_NONCONVERT	=1D	IME nonconvert
        //public const int VK_ACCEPT	=1E	IME accept
        //public const int VK_MODECHANGE	1F	IME mode change request
        //public const int VK_SPACE	=20	SPACEBAR
        //public const int VK_PRIOR	=21	PAGE UP key
        //public const int VK_NEXT	=22	PAGE DOWN key
        //public const int VK_END	    =23	END key
        //public const int VK_HOME	=24	HOME key
        //public const int VK_LEFT	=25	LEFT ARROW key
        //public const int VK_UP	=26	UP ARROW key
        //public const int VK_RIGHT	=27	RIGHT ARROW key
        //public const int VK_DOWN	=28	DOWN ARROW key
        //public const int VK_SELECT	=29	SELECT key
        //public const int VK_PRINT	=2A	PRINT key
        //public const int VK_EXECUTE	=2B	EXECUTE key
        //public const int VK_SNAPSHOT	=2C	PRINT SCREEN key
        //public const int VK_INSERT	=2D	INS key
        //public const int VK_DELETE	=2E	DEL key
        //public const int VK_HELP	=2F	HELP key

        //30	0 key

        //31	1 key

        //32	2 key

        //33	3 key

        //34	4 key

        //35	5 key

        //36	6 key

        //37	7 key

        //38	8 key

        //39	9 key
        //��	3A�C40	Undefined

        //41	A key

        //42	B key

        //43	C key

        //44	D key

        //45	E key

        //46	F key

        //47	G key

        //48	H key

        //49	I key

        //4A	J key

        //4B	K key

        //4C	L key

        //4D	M key

        //4E	N key

        //4F	O key

        //50	P key

        //51	Q key

        //52	R key

        //53	S key

        //54	T key

        //55	U key

        //56	V key

        //57	W key

        //58	X key

        //59	Y key

        //5A	Z key
        //VK_LWIN	5B	Left Windows key (Microsoft? Natural? keyboard)
        //VK_RWIN	5C	Right Windows key (Natural keyboard)
        //VK_APPS	5D	Applications key (Natural keyboard)
        //��	5E	Reserved
        //VK_SLEEP	5F	Computer Sleep key
        //VK_NUMPAD0	60	Numeric keypad 0 key
        //VK_NUMPAD1	61	Numeric keypad 1 key
        //VK_NUMPAD2	62	Numeric keypad 2 key
        //VK_NUMPAD3	63	Numeric keypad 3 key
        //VK_NUMPAD4	64	Numeric keypad 4 key
        //VK_NUMPAD5	65	Numeric keypad 5 key
        //VK_NUMPAD6	66	Numeric keypad 6 key
        //VK_NUMPAD7	67	Numeric keypad 7 key
        //VK_NUMPAD8	68	Numeric keypad 8 key
        //VK_NUMPAD9	69	Numeric keypad 9 key
        //VK_MULTIPLY	6A	Multiply key
        //VK_ADD	6B	Add key
        //VK_SEPARATOR	6C	Separator key
        //VK_SUBTRACT	6D	Subtract key
        //VK_DECIMAL	6E	Decimal key
        //VK_DIVIDE	6F	Divide key
        //VK_F1	70	F1 key
        //VK_F2	71	F2 key
        //VK_F3	72	F3 key
        //VK_F4	73	F4 key
        //VK_F5	74	F5 key
        //VK_F6	75	F6 key
        //VK_F7	76	F7 key
        //VK_F8	77	F8 key
        //VK_F9	78	F9 key
        //VK_F10	79	F10 key
        //VK_F11	7A	F11 key
        //VK_F12	7B	F12 key
        //VK_F13	7C	F13 key
        //VK_F14	7D	F14 key
        //VK_F15	7E	F15 key
        //VK_F16	7F	F16 key
        //VK_F17	80H	F17 key
        //VK_F18	81H	F18 key
        //VK_F19	82H	F19 key
        //VK_F20	83H	F20 key
        //VK_F21	84H	F21 key
        //VK_F22	85H	F22 key
        //VK_F23	86H	F23 key
        //VK_F24	87H	F24 key
        //��	88�C8F	Unassigned
        //VK_NUMLOCK	90	NUM LOCK key
        //VK_SCROLL	91	SCROLL LOCK key

        //92�C96	OEM specific
        //��	97�C9F	Unassigned
        //VK_LSHIFT	A0	Left SHIFT key
        //VK_RSHIFT	A1	Right SHIFT key
        //VK_LCONTROL	A2	Left CONTROL key
        //VK_RCONTROL	A3	Right CONTROL key
        //VK_LMENU	A4	Left MENU key
        //VK_RMENU	A5	Right MENU key
        //VK_BROWSER_BACK	A6	Windows 2000/XP: Browser Back key
        //VK_BROWSER_FORWARD	A7	Windows 2000/XP: Browser Forward key
        //VK_BROWSER_REFRESH	A8	Windows 2000/XP: Browser Refresh key
        //VK_BROWSER_STOP	A9	Windows 2000/XP: Browser Stop key
        //VK_BROWSER_SEARCH	AA	Windows 2000/XP: Browser Search key
        //VK_BROWSER_FAVORITES	AB	Windows 2000/XP: Browser Favorites key
        //VK_BROWSER_HOME	AC	Windows 2000/XP: Browser Start and Home key
        //VK_VOLUME_MUTE	AD	Windows 2000/XP: Volume Mute key
        //VK_VOLUME_DOWN	AE	Windows 2000/XP: Volume Down key
        //VK_VOLUME_UP	AF	Windows 2000/XP: Volume Up key
        //VK_MEDIA_NEXT_TRACK	B0	Windows 2000/XP: Next Track key
        //VK_MEDIA_PREV_TRACK	B1	Windows 2000/XP: Previous Track key
        //VK_MEDIA_STOP	B2	Windows 2000/XP: Stop Media key
        //VK_MEDIA_PLAY_PAUSE	B3	Windows 2000/XP: Play/Pause Media key
        //VK_LAUNCH_MAIL	B4	Windows 2000/XP: Start Mail key
        //VK_LAUNCH_MEDIA_SELECT	B5	Windows 2000/XP: Select Media key
        //VK_LAUNCH_APP1	B6	Windows 2000/XP: Start Application 1 key
        //VK_LAUNCH_APP2	B7	Windows 2000/XP: Start Application 2 key
        //��	B8-B9	Reserved
        //VK_OEM_1	BA	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the ';:' key

        //VK_OEM_PLUS	BB	Windows 2000/XP: For any country/region, the '+' key
        //VK_OEM_COMMA	BC	Windows 2000/XP: For any country/region, the ',' key
        //VK_OEM_MINUS	BD	Windows 2000/XP: For any country/region, the '-' key
        //VK_OEM_PERIOD	BE	Windows 2000/XP: For any country/region, the '.' key
        //VK_OEM_2	BF	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the '/?' key

        //VK_OEM_3	C0	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the '`~' key

        //��	C1�CD7	Reserved
        //��	D8�CDA	Unassigned
        //VK_OEM_4	DB	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the '[{' key

        //VK_OEM_5	DC	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the '\|' key

        //VK_OEM_6	DD	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the ']}' key

        //VK_OEM_7	DE	Used for miscellaneous characters; it can vary by keyboard.
        //Windows 2000/XP: For the US standard keyboard, the 'single-quote/double-quote' key

        //VK_OEM_8	DF	Used for miscellaneous characters; it can vary by keyboard.
        //��	E0	Reserved

        //E1	OEM specific
        //VK_OEM_102	E2	Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard

        //E3�CE4	OEM specific
        //VK_PROCESSKEY	E5	Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key

        //E6	OEM specific
        //VK_PACKET	E7	Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        //��	E8	Unassigned

        //E9�CF5	OEM specific
        //VK_ATTN	F6	Attn key
        //VK_CRSEL	F7	CrSel key
        //VK_EXSEL	F8	ExSel key
        //VK_EREOF	F9	Erase EOF key
        //VK_PLAY	FA	Play key
        //VK_ZOOM	FB	Zoom key
        //VK_NONAME	FC	Reserved for future use
        //VK_PA1	FD	PA1 key
        //VK_OEM_CLEAR	FE	Clear key

        #endregion
    }
}
