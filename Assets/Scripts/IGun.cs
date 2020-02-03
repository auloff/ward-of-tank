public interface IGun
{
    float Delay { get; }
    void Shoot();
    void TurnOn();
    void TurnOff();
}