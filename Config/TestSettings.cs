namespace PlayWrightCSharp.Config;

public class TestSettings
{
    public string[] Args { get; set; }
    public bool Headless { get; set; }
    public int SlowMo { get; set; }
    public  float Timeout { get; set; }
    public DriverType DriverType { get; set; }
}

public enum DriverType
{
    Chrome,
    Chromium,
    Edge,
    Firefox,
    WebKit
}
