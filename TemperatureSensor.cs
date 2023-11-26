namespace Exercise004
{
  public class TemperatureSensor : ISensor
  {
    private Random random;
    private bool sensor;

    public TemperatureSensor()
    {
        //コンストラクタ
        this.random = new Random();
        this.sensor = false;
    }

    public bool IsOn()
    {
        // returns true if the sensor is on
        return this.sensor;
    }

    public void SetOn()
    {
        // sets the sensor on
        this.sensor = true;
    }

    public void SetOff()
    {
        // sets the sensor off
        this.sensor = false;
    }

    public int Read()
    {
        // returns the value of the sensor if it's on
        // if the sensor is not on throw a IllegalStateException
        if(IsOn())
        {
            return this.random.Next(-30,31);
        }
        throw new InvalidOperationException("Sensor not on!");
    }
  }
}