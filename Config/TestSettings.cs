namespace PlayWrightCSharp.Config;

public class TestSettings
{
    public bool Headless { get; set; }
    public string Channel { get; set; }
    public int SlowMo { get; set; }
    public DriverType DriverType { get; set; }
}

public enum DriverType
{
    Chromium,
    Firefox,
    Edge,
    Chrome,
    WebKit
}
