public static class CommandConstants
{
    public static string SetPS2KeyboardStartTypeToDisabled = "sc config i8042prt start= disabled";
    public static string SetPS2KeyboardStartTypeToAuto = "sc config i8042prt start= auto";
    public static string GetPS2KeyboardStatus = "wmic path Win32_PnPEntity where \"Name like '%{0}%'\" get Status";

}