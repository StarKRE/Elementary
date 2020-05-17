namespace OregoFramework.Util
{
    public interface IMotor
    {
        void AddForce(float coefficient);

        float NextSpeed();

        void Reset();
    }
}