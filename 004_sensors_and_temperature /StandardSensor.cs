namespace Exercise004
{
  public class StandardSensor : ISensor
  {
    public int number;

    public StandardSensor(int number)
    {
        //コンストラクタ
        this.number = number;
    }

    public bool IsOn()
    {
        // returns true if the sensor is on
        return true;
    }

    public void SetOn()
    {
        // sets the sensor on
    }

    public void SetOff()
    {
        // sets the sensor off
    }

    public int Read()
    {
        // returns the value of the sensor if it's on
        return this.number;
        // if the sensor is not on throw a IllegalStateException
    }
  }
}
