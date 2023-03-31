// See https://aka.ms/new-console-template for more information
using Keystrokes;

Console.WriteLine("Hello, World!");

KeystrokesManager manager = new();
await manager.CaptureAsync().ConfigureAwait(false);
